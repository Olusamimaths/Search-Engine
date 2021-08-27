using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class PathHandler
    {
        public static string GetBasePath()
        {
            string appdomain = AppDomain.CurrentDomain.BaseDirectory;
            string newPath = Path.GetFullPath(Path.Combine(appdomain, @"..\..\..\"));
            Logger.Info("appdomain" + appdomain);
            Logger.Info("newPath" + newPath);
            return newPath;
        }
        public static string GetFilePath(string path)
        {
            string appdomain = AppDomain.CurrentDomain.BaseDirectory;
            string newPath = Path.GetFullPath(Path.Combine(appdomain, @"..\..\..\"));
            Logger.Info("appdomain" + appdomain);
            Logger.Info("newPath" + newPath);
            return newPath;
        }
    }
}
