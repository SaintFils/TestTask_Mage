using System;
using Client.Scripts.Player;
using UnityEngine;

namespace Client.Scripts.UI
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBar;

        private PlayerHealth playerHealth;

        public void Construct(PlayerHealth health)
        {
            playerHealth = health;

            playerHealth.HealthChanged += UpdateHealthBar;
        }
        
        private void UpdateHealthBar()
        {
            healthBar.SetValue(playerHealth.CurrentHealth, playerHealth.MaxHealth);
        }

        private void OnDestroy() => playerHealth.HealthChanged -= UpdateHealthBar;
    }
}