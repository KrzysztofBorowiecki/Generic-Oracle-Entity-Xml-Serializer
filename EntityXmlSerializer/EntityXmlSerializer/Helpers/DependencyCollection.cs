using Microsoft.Extensions.DependencyInjection;
using EntityXmlSerializer.Tools;
using EntityXmlSerializer.Data;

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
               .AddSingleton<ModelContext>()
               .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
