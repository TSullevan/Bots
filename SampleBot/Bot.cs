using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SampleBot.Interfaces;
using SampleBot.Models;
using SampleBot.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Trello;
using Xsys.Discord;

namespace SampleBot
{
    public class Bot : IBot
    {
        private Settings _settings { get; set; }
        private IConfiguration _configuration { get; set; }
        private IBotService _botService { get; set; }
        private ITrelloOptions _trelloOptions;
        private TrelloConnector _trelloConnector { get; set; }
        public Bot(IConfiguration configuration, IBotService botService, IOptions<TrelloOptions> trelloOptions)
        {
            _configuration = configuration;
            _botService = botService;
            _trelloOptions = trelloOptions.Value;
        }

        public void Configure()
        {
            _settings = _configuration.GetSection("Settings").Get<Settings>();
            _trelloConnector = new TrelloConnector(_trelloOptions);
        }

        public async Task RunAsync()
        {
            int fromPhase = _settings.InitialPhase;
            int nextPhase = _settings.NextPhase;
            try
            {
                var documents = await _botService.GetDocumentsByPhase(fromPhase);
                await _botService.MoveToNextPhase(documents, nextPhase);
                var discord = new DiscordConnector()
                {
                    username = "ChangePhaseBot",
                    message = $"Testando 1,2,3..."
                };

                await discord.SendDiscordMessage();
            }
            catch(Exception exception)
            {
                await _trelloConnector.CreateCard("ChangePhaseBot", _trelloOptions.TrelloListId, exception.Message, _trelloOptions.TrelloLabelsId);
            }
        }

        public bool Validate()
        {
            return true;
        }
    }
}
