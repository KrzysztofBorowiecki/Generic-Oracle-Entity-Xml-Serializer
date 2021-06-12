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

        public static DirectoryInfo GetDirectoryInfo(string path, string appName)
        {
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine($"{appName}: directory parametr is null or empty");
                Exit(exitCode: 1);
            }
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            return dirInfo;
        }
    }
}
