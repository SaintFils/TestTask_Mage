using System;
using Client.Scripts.Logic;
using UnityEngine;

namespace Client.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float currentHealth;
        [SerializeField] private float maxHealth;
        [SerializeField] private float armor;

        public event Action HealthChanged;

        public float CurrentHealth
        {
            get => currentHealth;
            set => currentHealth = value;
        }

        public float MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        public float Armor
        {
            get => armor;
            set => armor = value;
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage * Armor;
            
            HealthChanged?.Invoke();
        }
    }
}