
namespace Indexing
{
    public class Document
    {
        public Document(int id, string text) {
            Id = id;
            Text = text;
        }
        public int Id { get; private set; }
        public string Text { get; private set; }
    }
}
