using JNogueira.Discord.Webhook.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Xsys.Discord
{
    public class DiscordConnector : IDiscordConnector
    {
        public string message;
        public string username;
        public string avatarUrl;
        public string file;
        public string webHookUrl;

        public async Task SendDiscordMessage()
        {
            try
            {
                DiscordWebhookClient hook = new DiscordWebhookClient(this.webHookUrl ?? "https://discord.com/api/webhooks/898268753178005584/sFGPM_jOsEGUXgDiWn_bASKorx0q1LNjgOfP1656s6d0EIGq7le5Egb6qp7_iQarKzhR");

                var discordMessage = new DiscordMessage(
                content: this.message,
                username: this.username ?? "Up Robo",
                avatarUrl: this.avatarUrl ?? "https://media-exp1.licdn.com/dms/image/C4D0BAQGuwfE6kLBdcA/company-logo_200_200/0/1560266636031?e=1642032000&v=beta&t=CBekM6h8vaQjOdMY56meGYFhttDGh58ja__7vxsli3g",
                tts: false
            );

                // Send the message!
                if (string.IsNullOrEmpty(this.file))
                {
                    await hook.SendToDiscord(discordMessage, true);
                }
                else
                {
                    await hook.SendToDiscord(discordMessage, new[] { new DiscordFile(file, Encoding.UTF8.GetBytes(file)) }, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
