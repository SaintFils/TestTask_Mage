using System.Linq;
using Client.Scripts.Data;
using Client.Scripts.Infrastructure.Services;
using Client.Scripts.Infrastructure.Services.Input;
using Client.Scripts.Infrastructure.Services.Progress;
using Client.Scripts.Logic;
using UnityEngine;

namespace Client.Scripts.Player
{
    public class PlayerAttack : MonoBehaviour, ISavedProgressReader
    {
        [SerializeField] private float cleavage = 1f;
        
        private const string LayerName = "Hittable";
        private int layerMask;
        private Collider[] hits = new Collider[10];
        private IInputService input;
        private Stats stats;

        private void Awake()
        {
            input = ServiceLocator.Container.Single<IInputService>();

            layerMask = 1 << LayerMask.NameToLayer(LayerName); 
        }

        private void Update()
        {
            if( input.IsAttackButtonPressed())
                Attack();
        }

        private void Attack()
        {
            if (Hit(out Collider hit))
            {
                hit.transform.parent.GetComponent<IHealth>().TakeDamage(stats.Damage);
            } 
        }
        
        private bool Hit(out Collider hit)
        {
            int hitsCount = Physics.OverlapSphereNonAlloc(transform.position, cleavage, hits, layerMask);

            hit = hits.FirstOrDefault();
            
            return hitsCount > 0;
        } 

        public void LoadProgress(PlayerProgress progress) => stats = progress.PlayerStats;
    }
}