using UnityEngine;
using UnityEngine.AI;

namespace Client.Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]
    public class AnimationAlongAgent : MonoBehaviour
    {
        private const float MinimalVelocity = 0.1f;
        
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private EnemyAnimator animator;


        private void Update()
        {
            if(ShouldMove())
                animator.PlayMove();
            else
                animator.StopMove();
        }

        private bool ShouldMove() => agent.velocity.magnitude > MinimalVelocity && agent.remainingDistance > agent.radius;
    }
}