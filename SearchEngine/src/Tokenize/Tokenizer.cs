using System.Collections.Generic;
using System.IO;

namespace Tokenize
{
	/// <summary>
	/// Tokenizer class that breaks a string into valid tokens
	/// </summary>
	public class Tokenizer : ITokenSource
	{
		private bool _quoted;
		private TextReader _reader;

		private static readonly string[] DefaultStopWords =
		{
			     "a",
            "about",
            "above",
            "after",
            "again",
            "against",
            "aint",
            "ain't",
            "all",
            "also",
            "am",
            "an",
            "and",
            "any",
            "are",
            "arent",
            "aren't",
            "as",
            "at",
            "be",
            "because",
            "been",
            "before",
            "being",
            "below",
            "between",
            "both",
            "but",
            "by",
            "cant",
            "can't",
            "cannot",
            "could",
            "couldnt",
            "couldn't",
            "did",
            "didnt",
            "didn't",
            "do",
            "does",
            "doesnt",
            "doesn't",
            "doing",
            "dont",
            "don't",
            "down",
            "during",
            "each",
            "few",
            "for",
            "from",
            "further",
            "had",
            "hadnt",
            "hadn't",
            "has",
            "hasnt",
            "hasn't",
            "have",
            "havent",
            "haven't",
            "having",
            "he",
            "hed",
            "he'd",
            "he'll",
            "hes",
            "he's",
            "her",
            "here",
            "heres",
            "here's",
            "hers",
            "herself",
            "him",
            "himself",
            "his",
            "how",
            "hows",
            "how's",
            "i",
            "id",
            "i'd",
            "i'll",
            "im",
            "i'm",
            "ive",
            "i've",
            "if",
            "in",
            "into",
            "is",
            "isnt",
            "isn't",
            "it",
            "its",
            "it's",
            "its",
            "itself",
            "lets",
            "let's",
            "me",
            "more",
            "most",
            "mustnt",
            "mustn't",
            "my",
            "myself",
            "no",
            "nor",
            "not",
            "of",
            "off",
            "on",
            "once",
            "only",
            "or",
            "other",
            "ought",
            "our",
            "ours",
            "ourselves",
            "out",
            "over",
            "own",
            "same",
            "shall",
            "shant",
            "shan't",
            "she",
            "she'd",
            "she'll",
            "shes",
            "she's",
            "should",
            "shouldnt",
            "shouldn't",
            "so",
            "some",
            "such",
            "than",
            "that",
            "thats",
            "that's",
            "the",
            "their",
            "theirs",
            "them",
            "themselves",
            "then",
            "there",
            "theres",
            "there's",
            "these",
            "they",
            "theyd",
            "they'd",
            "theyll",
            "they'll",
            "theyre",
            "they're",
            "theyve",
            "they've",
            "this",
            "those",
            "thou",
            "though",
            "through",
            "to",
            "too",
            "under",
            "until",
            "unto",
            "up",
            "very",
            "was",
            "wasnt",
            "wasn't",
            "we",
            "we'd",
            "we'll",
            "were",
            "we're",
            "weve",
            "we've",
            "werent",
            "weren't",
            "what",
            "whats",
            "what's",
            "when",
            "whens",
            "when's",
            "where",
            "wheres",
            "where's",
            "which",
            "while",
            "who",
            "whos",
            "who's",
            "whose",
            "whom",
            "why",
            "whys",
            "why's",
            "with",
            "wont",
            "won't",
            "would",
            "wouldnt",
            "wouldn't",
            "you",
            "youd",
            "you'd",
            "youll",
            "you'll",
            "youre",
            "you're",
            "youve",
            "you've",
            "your",
            "yours",
            "yourself",
            "yourselves"
		};

		private readonly HashSet<string> _stopWords = new HashSet<string>(DefaultStopWords);

		public Tokenizer(int maxBufferSize = 256)
		{
			Buffer = new char[maxBufferSize];
		}

		public void SetReader(TextReader reader)
		{
			_reader = reader;
			Size = 0;
			_quoted = false;
		}

		public char[] Buffer { get; private set; }

		public int Size { get; set; }

		public int Line { get; private set; }

		public int Column { get; private set; }
		public int Position { get; set; }

		private bool BufferFull
		{
			get { return Buffer.Length == Size; }
		}

		public bool Next()
		{
			Size = 0;
			Position++;
			char ch = '\0';
			while (true)
			{
				char prev = ch;
				int r = _reader.Read();
				Column++;
				if (r == -1) // EOF
				{
					if (_quoted && Size > 0)
					{
						// we have an unterminated string, so we will ignore the quote, instead of erroring
						SetReader(new StringReader(new string(Buffer, 0, Size)));
						ch = '\0';
						continue;
					}
					return Size > 0;
				}

				ch = (char)r;
				if (ch == '\r' || ch == '\n')
				{
					Column = 0;
					if (prev != '\r' || ch != '\n')
					{
						Line++; // only move to new line if it isn't the \n in a \r\n pair
					}
					if (_quoted)
					{
						AppendToBuffer(ch);
						if (BufferFull)
						{
							return true;
						}
					}
					else if (Size > 0)
						return true;
					continue;
				}
				if (char.IsWhiteSpace(ch))
				{
					if (_quoted) // for a quoted string, we will continue until the end of the string
					{
						AppendToBuffer(ch);
						if (BufferFull)
						{
							return true;
						}
					}
					else if (Size > 0) // if we have content before, we will return this token
						return true;
					continue;
				}
				if (ch == '"')
				{
					if (_quoted == false)
					{
						_quoted = true;
						if (Size > 0)
							return true; // return the current token
						continue;
					}
					_quoted = false;
					return true;
				}

				if (char.IsPunctuation(ch))
				{
					// if followed by whitespace, ignore
					int next = _reader.Peek();
					if (next == -1 || char.IsWhiteSpace((char)next))
						continue;
				}

				if (ch == '.' || ch == '\'') {
					return true;
				}

				AppendToBuffer(ch);
				if (BufferFull)
					return true;
			}
		}

		/// <summary>
		/// Iterates through given input and extract valid tokens
		/// </summary>
		/// <returns>List: List of valid words called terms that can be indexed</returns>
		public List<string> ReadAll()
		{
			List<string> result = new List<string>();

			while (Next())
            {
                string _next = new string(Buffer, 0, Size);
				//Skip stop words
				if (_stopWords.Contains(_next.ToLower()) || _next.Length < 2)
                {
                   continue;
                }
                result.Add(ToString());
            }
            return result;
		}


		private void AppendToBuffer(char curr)
		{
			Buffer[Size++] = curr;
		}

		public override string ToString()
		{
			return new string(Buffer, 0, Size).ToLower();
        }
	}
}