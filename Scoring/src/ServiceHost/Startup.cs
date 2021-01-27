using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Scoring.Config;
using Scoring.Config.Configuration;

namespace ServiceHost
{
    public class Startup
    {
        private ScoringConfiguration _scoringConfig;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _scoringConfig = Configuration.GetSection("ScoringConfig").Get<ScoringConfiguration>();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMassTransitConsumers(_scoringConfig.Bus);
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ScoringModule(_scoringConfig));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
