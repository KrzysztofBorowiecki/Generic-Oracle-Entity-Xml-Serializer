using Microsoft.Extensions.DependencyInjection;
using EntityXmlSerializer.Tools;

namespace EntityXmlSerializer.Helpers
{
    public static class DependencyCollection
    {
        public static ServiceProvider Register()
        {
            var serviceProvider = new ServiceCollection()
               .AddLogging()
               .AddTransient<Exporter>()
               .AddTransient<Importer>()
               .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
