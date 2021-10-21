using Microsoft.Extensions.DependencyInjection;
using SampleBot.Interfaces;
using System;
using System.Threading.Tasks;

namespace SampleBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Startup startup = new Startup();
                var robot = startup.Provider.GetRequiredService<IBot>();

                robot.Configure();

                if (robot.Validate())
                {
                    await robot.RunAsync();
                }
                else
                {
                    //TODO: Tratativa para erros de validação.
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
