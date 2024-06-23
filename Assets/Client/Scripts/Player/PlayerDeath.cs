using System;
using UnityEngine;

namespace Client.Scripts.Player
{
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerHealth health;
        [SerializeField] private PlayerMove move;
        [SerializeField] private GameObject deathEffect;
        private bool isDead;

        private void Start() => health.HealthChanged += HealthChanged;

        private void OnDestroy() => health.HealthChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (!isDead && health.CurrentHealth <= 0)
                Die();
        }

        private void Die()
        {
            isDead = true;
            
            move.enabled = false;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }
}