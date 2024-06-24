using Client.Scripts.Logic;
using UnityEngine;

namespace Client.Scripts.UI
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBar;

        private IHealth health;

        public void Construct(IHealth health)
        {
            this.health = health;

            this.health.HealthChanged += UpdateHealthBar;
        }

        private void Start()
        {
            IHealth healthComp = GetComponent<IHealth>();
      
            if(healthComp != null)
                Construct(healthComp);
        }

        private void OnDestroy()
        {
            if(health != null)
                health.HealthChanged -= UpdateHealthBar;
        }

        private void UpdateHealthBar()
        {
            healthBar.SetValue(health.CurrentHealth, health.MaxHealth);
        }
    }
}