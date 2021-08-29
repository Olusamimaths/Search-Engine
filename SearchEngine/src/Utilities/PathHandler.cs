using System;
using System.IO;


namespace Utilities
{
    public static class PathHandler
    {
        public static string GetBasePath()
        {
            string appdomain = AppDomain.CurrentDomain.BaseDirectory;
            string newPath = Path.GetFullPath(Path.Combine(appdomain, @"..\..\..\"));
            return newPath;
        }

        //Parent directory 
        public static string GetParentBasePath(string path)
        {
            return Directory.GetParent(GetBasePath()).Parent.FullName + "\\SearchEngine\\uploads" + path;
        }

        public static string GetFilePath(string path)
        {
            string basePath = GetBasePath();
            return basePath + path;
        }
    }
}
