using Mono.Options;

namespace EntityXmlSerializer.Helpers
{
    public static class InputParameters
    {
        public static bool IsExporting { get; private set; }
        public static bool IsImporting { get; private set; }
        public static string XmlDirectoryPath { get; private set; }

        private static readonly OptionSet Options = new()
        {
            {
                "e|export",
                "declares whether the tool should export `.xml`",
                e => IsExporting = e != null
            },
            {
                "i|import",
                "declares whether the tool should import the `.xml`",
                e => IsImporting = e != null
            },
            {
                "d|directory=",
                "the absolute path to file with `.xml`",
                file => XmlDirectoryPath = file
            },
        };

        public static OptionSet GetOptionSet()
        {
            return Options;
        }
    }
}
