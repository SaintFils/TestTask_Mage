using System.Linq;
using Client.Scripts.Infrastructure.Factory;
using Client.Scripts.Infrastructure.Services;
using Client.Scripts.Logic;
using UnityEngine;

namespace Client.Scripts.Enemy
{
    public class Attack : MonoBehaviour
    {
        private const string LayerPlayer = "Player";
        
        [SerializeField] private EnemyAnimator animator;
        [SerializeField] private float attackCooldown = 1f;
        [SerializeField] private float cleavage = .5f;
        [SerializeField] private float effectiveDistance = .5f;
        [SerializeField] private float damage = 5f;

        private IGameFactory factory;
        private Transform playerTransform;
        private float timer;
        private bool isAttacking;
        private bool isAttackAvailable;
        private int layerMask;
        private Collider[] hits = new Collider[1];

        private void Awake()
        {
            factory = ServiceLocator.Container.Single<IGameFactory>();

            layerMask = 1 << LayerMask.NameToLayer(LayerPlayer);
            
            factory.PlayerCreated += OnPlayerCreated;
        }

        private void Update()
        {
            if (IsOnCooldown())
                timer -= Time.deltaTime;
            
            if(CanAttack())
                StartAttack();
        }

        private void OnDestroy()
        {
            factory.PlayerCreated -= OnPlayerCreated;
        }

        public void EnableAttack() => isAttackAvailable = true;

        public void DisableAttack() => isAttackAvailable = false;

        private void OnAttack()
        {
            if (Hit(out Collider hit))
            {
               VisualAttackHitDebug.DrawDebug(HitPosition(), cleavage, 1.5f);
               hit.transform.GetComponent<IHealth>().TakeDamage(damage);
            }
        }

        private void OnAttackEnded()
        {
            timer = attackCooldown;
            isAttacking = false;
        }

        private bool Hit(out Collider hit)
        {
            int hitsCount = Physics.OverlapSphereNonAlloc(HitPosition(), cleavage, hits, layerMask);

            hit = hits.FirstOrDefault();
            
            return hitsCount > 0;
        }

        private Vector3 HitPosition() => new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) + transform.forward * effectiveDistance;

        private void StartAttack()
        {
            transform.LookAt(playerTransform);  
            animator.PlayAttack();

            isAttacking = true;
        }

        private bool CanAttack() => isAttackAvailable && !isAttacking && !IsOnCooldown();

        private bool IsOnCooldown() => timer > 0;

        private void OnPlayerCreated() => playerTransform = factory.PlayerGameObject.transform;
    }
}