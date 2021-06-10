using System;
using System.IO;

namespace EntityXmlSerializer.Utils
{
    public static class Utils
    {
        public static void Exit(string message = null, int exitCode = 0)
        {
            if (message != null)
            {
                Console.WriteLine(message);
            }

            Environment.Exit(exitCode);
        }

        public static DirectoryInfo GetDirectoryInfo(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            return dirInfo;
        }
    }
}
