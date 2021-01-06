using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.OutboxProcessor.DataStore;
using Framework.OutboxProcessor.DataStore.Sql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Framework.OutboxProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IDataStore, SqlDataStore>();
                    services.Configure<SqlStoreConfig>(hostContext.Configuration.GetSection("SqlStoreConfig"));
                    services.AddHostedService<Worker>();
                });
    }
}
