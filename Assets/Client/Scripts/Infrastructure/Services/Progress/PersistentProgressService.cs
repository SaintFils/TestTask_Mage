using Client.Scripts.Data;

namespace Client.Scripts.Infrastructure.Services.Progress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}