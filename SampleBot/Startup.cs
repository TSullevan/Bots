using Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Connections;
using Repository.Connections.Interfaces;
using Repository.Interfaces;
using SampleBot.Interfaces;
using SampleBot.Services;
using SampleBot.Services.Interfaces;
using System;
using System.IO;
using Trello;

namespace SampleBot
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider provider;

        public IServiceProvider Provider => provider;
        public IConfiguration Configuration => _configuration;

        public Startup()
        {
            _configuration = new ConfigurationBuilder()
#if DEBUG
                .SetBasePath(Directory.GetCurrentDirectory() + "/../../..")
#else
                .SetBasePath(Directory.GetCurrentDirectory())
#endif
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            ServiceCollection services = new ServiceCollection();

            services.AddSingleton(_configuration);
            services.AddSingleton<ITrelloConnector, TrelloConnector>();

            #region Configurations
            services.Configure<ITrelloOptions>(_configuration.GetSection("TrelloSettings"));
            #endregion

            #region Contexts and Procs
            services.AddDbContext<SampleContext>(config =>
            {
                config.UseSqlServer(_configuration.GetConnectionString("dbSample"));
            });
            #endregion

            #region Connections
            services.AddTransient<ISampleConnection>(db => new SampleConnection(_configuration.GetConnectionString("dbSample")));
            #endregion

            #region Bot
            services.AddScoped<IBot, Bot>();
            #endregion

            #region Services
            services.AddScoped<IBotService, BotService>();
            #endregion

            #region Repositories
            services.AddScoped<IDocumentoRepository, DocumentoRepository>();
            #endregion

            provider = services.BuildServiceProvider();

        }
    }

}
