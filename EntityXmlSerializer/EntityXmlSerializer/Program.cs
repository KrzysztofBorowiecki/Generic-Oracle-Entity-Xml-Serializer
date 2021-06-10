using System;
using System.IO;
using Mono.Options;

namespace EntityXmlSerializer
{
    class Program
    {
        private static bool isExporting;
        private static bool isImporting;

        public static string xmlDirectoryPath { get; private set; }

        private static readonly OptionSet Options = new()
        {
            {
                "e|export",
                "declares whether the tool should export `.xml`",
                e => isExporting = e != null
            },
            {
                "i|import",
                "declares whether the tool should import the `.xml`",
                e => isImporting = e != null
            },
            {
                "d|directory=",
                "the absolute path to file with `.xml`",
                file => xmlDirectoryPath = file
            },
        };
        static void Main(string[] args)
        {
            var appName = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);

            try
            {
                Options.Parse(args);
            }
            catch (OptionException)
            {
                Console.WriteLine($"{appName}: invalid parameters");
                return;
            }

            if (isExporting && isImporting)
            {
                Console.WriteLine($"{appName}: import and export flags cannot be set at the same time.");
                Utils.Utils.Exit(exitCode: 1);
            }

            if (!isExporting && !isImporting)
            {
                Console.WriteLine($"{appName}: either import or export flag needs to be set.");
                Utils.Utils.Exit(exitCode: 1);
            }

            try
            {
                if (isExporting)
                {

                }

                if (isImporting)
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{appName}: an error occurred.");
                Console.WriteLine($"\nMessage: {e.Message}");
                Utils.Utils.Exit(exitCode: 1);
            }
        }
    }
}
