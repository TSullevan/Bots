using System.Threading.Tasks;

namespace Xsys.Discord
{
    public interface IDiscordConnector
    {
        Task SendDiscordMessage();
    }
}
