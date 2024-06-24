using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Client.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyAnimator), typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator enemyAnimator;
        [SerializeField] private EnemyHealth enemyHealth;
        [SerializeField] private GameObject enemyDeathEffect;
        [SerializeField] private NavMeshAgent navMeshAgent;

        public event Action DeathHappend;

        private void Start() => enemyHealth.HealthChanged += EnemyHealthChanged;

        private void OnDestroy() => enemyHealth.HealthChanged -= EnemyHealthChanged;

        private void EnemyHealthChanged()
        {
            if (enemyHealth.CurrentHealth <= 0)
                Die();
        }

        private void Die()
        {
            enemyHealth.HealthChanged -= EnemyHealthChanged;
            enemyAnimator.PlayDeath();

            DeathEffect();
            navMeshAgent.speed = 0;
            StartCoroutine(DestroyTimer());
            
            DeathHappend?.Invoke();
        }

        private void DeathEffect() => Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}