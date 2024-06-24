using System;

namespace Client.Scripts.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public HealthStatus HealthStatus;
        public WorldData WorldData;
        public Stats PlayerStats;

        public PlayerProgress(string initialLevel)
        {
            PlayerStats = new Stats();
            WorldData = new WorldData(initialLevel);
            HealthStatus = new HealthStatus();
        }
    }
}