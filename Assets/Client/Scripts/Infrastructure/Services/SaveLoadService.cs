using Client.Scripts.Data;
using Client.Scripts.Infrastructure.Factory;
using Client.Scripts.Infrastructure.Services.Progress;
using UnityEngine;

namespace Client.Scripts.Infrastructure.Services
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistentProgressService progressService;
        private readonly IGameFactory gameFactory;
        private const string ProgressKey = "Progress";

        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            this.progressService = progressService;
            this.gameFactory = gameFactory;
        }
        
        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(progressService.Progress);
            
            PlayerPrefs.SetString(ProgressKey, progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() => PlayerPrefs.GetString(ProgressKey)?.ToDeserialize<PlayerProgress>();
    }
}