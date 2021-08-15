using System;
using Utilities;

namespace Utilities
{
    /// <summary>
    /// Class for Converting all cases to lower
    /// </summary>
    public static class CaseFolder
    {
        /// <summary>
        /// converts all strings to lower case
        /// </summary>
        /// <param name="word">String: The word to be folded</param>
        /// <returns>String: The word converted to lower case</returns>
        public static string CaseFold(string word)
        {
            return word.ToLower();
        }
    }
}
