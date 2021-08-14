using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    /// <summary>
    /// Logger Class for logging information
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Logs general text while app is running
        /// </summary>
        /// <param name="text">String: The text to log</param>
        public static void Info(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Logs error messages
        /// </summary>
        /// <param name="text">String: The error text</param>
        public static void Error(string text)
        {
            // Change the foreground color to red before printing
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            // restore foreground color to white after printing
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
