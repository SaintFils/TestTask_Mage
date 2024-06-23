using Client.Scripts.Data;

namespace Client.Scripts.Infrastructure.Services
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}