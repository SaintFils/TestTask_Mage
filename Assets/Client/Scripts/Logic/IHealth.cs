using System;

namespace Client.Scripts.Logic
{
    public interface IHealth
    {
        event Action HealthChanged;
        float CurrentHealth { get; set; }
        float MaxHealth { get; set; }
        float Armor { get; set; }
        void TakeDamage(float damage);
    }
}