using Client.Scripts.Data;

namespace Client.Scripts.Infrastructure.Services.Progress
{
    public interface IPersistentProgressService : IService
    {
    PlayerProgress Progress { get; set; }
    }
}