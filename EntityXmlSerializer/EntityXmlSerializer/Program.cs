using System;
using System.IO;
using Mono.Options;
using EntityXmlSerializer.Tools;
using EntityXmlSerializer.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace EntityXmlSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var appName = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
            var options = InputParameters.GetOptionSet();

            try
            {
                options.Parse(args);
            }
            catch (OptionException)
            {
                Console.WriteLine($"{appName}: invalid parameters");
                return;
            }

            var serviceProvider = DependencyCollection.Register();
            var directoryInfo = Utils.Utils.GetDirectoryInfo(InputParameters.XmlDirectoryPath, appName);

            if (InputParameters.IsExporting && InputParameters.IsImporting)
            {
                Console.WriteLine($"{appName}: import and export flags cannot be set at the same time.");
                Utils.Utils.Exit(exitCode: 1);
            }
            else if (!InputParameters.IsExporting && !InputParameters.IsImporting)
            {
                Console.WriteLine($"{appName}: either import or export flag needs to be set.");
                Utils.Utils.Exit(exitCode: 1);
            }


            if (!directoryInfo.Exists)
            {
                Console.WriteLine($"{appName}: directory not exists.");
                Utils.Utils.Exit(exitCode: 1);
            }


            try
            {
                if (InputParameters.IsExporting)
                {
                    var exporter = serviceProvider.GetService<Exporter>();
                    exporter.Invoke();
                }

                if (InputParameters.IsImporting)
                {
                    var importer = serviceProvider.GetService<Importer>();
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
