using System;
using Client.Scripts.Data;
using Client.Scripts.Infrastructure.Services.Progress;
using Client.Scripts.Logic;
using UnityEngine;

namespace Client.Scripts.Player
{
    public class PlayerHealth : MonoBehaviour, ISavedProgress, IHealth
    {
        private HealthStatus healthStatus;

        public event Action HealthChanged;
        
        public float CurrentHealth
        {
            get => healthStatus.CurrentHealth;
            set
            {
                if(healthStatus.CurrentHealth != value)
                {
                    healthStatus.CurrentHealth = value;

                    HealthChanged?.Invoke();
                }
            }
        }

        public float MaxHealth
        {
            get => healthStatus.MaxHealth;
            set => healthStatus.MaxHealth = value;
        }

        public float Armor
        {
            get => healthStatus.Armor;
            set => healthStatus.Armor = value;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            healthStatus = progress.HealthStatus;
            HealthChanged?.Invoke();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.HealthStatus.CurrentHealth = CurrentHealth;
            //save hp, max hp, etc
        }

        public void TakeDamage(float damage)
        {
            if(CurrentHealth <= 0)
                return;
            
            CurrentHealth -= damage * Armor;
        }
    }
}