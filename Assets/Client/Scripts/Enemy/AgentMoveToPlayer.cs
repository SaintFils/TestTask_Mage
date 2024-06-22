using Client.Scripts.Infrastructure.Factory;
using Client.Scripts.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace Client.Scripts.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        private const float MinimalDistance = 0.1f;
        
        public NavMeshAgent Agent;

        private IGameFactory gameFactory;
        private Transform playerTransform;

        private void Start()
        {
            gameFactory = ServiceLocator.Container.Single<IGameFactory>();

            if (gameFactory.PlayerGameObject != null)
                InitializePlayerTransform();
            else
                gameFactory.PlayerCreated += OnPlayerCreated;
            
        }

        private void Update()
        {
            if(playerTransform != null && IsPlayerNotReached())
                Agent.destination = playerTransform.position;
        }

        private void OnPlayerCreated() => InitializePlayerTransform();

        private void InitializePlayerTransform() => playerTransform = gameFactory.PlayerGameObject.transform;

        private bool IsPlayerNotReached() => Vector3.Distance(Agent.transform.position, playerTransform.position) >= MinimalDistance;
    }
}