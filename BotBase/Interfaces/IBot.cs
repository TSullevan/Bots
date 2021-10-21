using System.Threading.Tasks;

namespace SampleBot.Interfaces
{
    public interface IBot
    {
        public void Configure();
        public Task RunAsync();
        public bool Validate();
    }
}
