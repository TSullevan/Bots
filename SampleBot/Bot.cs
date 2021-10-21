using Contexts;
using Microsoft.Extensions.Configuration;
using SampleBot.Interfaces;
using SampleBot.Models;
using SampleBot.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBot
{
    public class Bot : IBot
    {
        private Settings _settings { get; set; }
        private IConfiguration _configuration { get; set; }
        public IBotService _botService { get; set; }
        public SampleContext conexaoBancoDeDados;
        public Bot(IConfiguration configuration, IBotService botService)
        {
            _configuration = configuration;
            _botService = botService;
        }

        public void Configure()
        {
            _settings = _configuration.GetSection("Settings").Get<Settings>();
        }

        public async Task RunAsync()
        {
            int fromPhase = _settings.InitialPhase;
            int nextPhase = _settings.NextPhase;
            var documents = await _botService.GetDocumentsByPhase(fromPhase);
            await _botService.MoveToNextPhase(documents, nextPhase);
        }

        public bool Validate()
        {
            return true;
        }
    }
}
