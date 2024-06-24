using System;

namespace Client.Scripts.Data
{
    [Serializable]
    public class HealthStatus
    {
        public float CurrentHealth;
        public float MaxHealth;
        public float Armor;

        public void ResetHealth() => CurrentHealth = MaxHealth;
    }
}