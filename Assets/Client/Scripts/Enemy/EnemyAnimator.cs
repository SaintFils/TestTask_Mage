using System;
using Client.Scripts.Logic;
using UnityEngine;



namespace Client.Scripts.Enemy
{
    public class EnemyAnimator : MonoBehaviour, IAnimationStateReader
    {
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Win = Animator.StringToHash("Win");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int IsMoving = Animator.StringToHash("isMoving");

        private readonly int idleStateHash = Animator.StringToHash("Idle");
        private readonly int attackStateHash = Animator.StringToHash("attack");
        private readonly int moveStateHash = Animator.StringToHash("move");
        private readonly int dieStateHash = Animator.StringToHash("Die");
        
        private Animator animator;

        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;
        
        public AnimatorState State { get; private set; }

        private void Awake() => animator = GetComponent<Animator>();

        public void PlayDeath() => animator.SetTrigger(Die);

        public void PlayAttack() => animator.SetTrigger(Attack);

        public void PlayWin() => animator.SetTrigger(Win);

        public void PlayMove() => animator.SetBool(IsMoving, true);

        public void StopMove() => animator.SetBool(IsMoving, false);

        public void EnteredState(int stateHash) => StateEntered?.Invoke(StateFor(stateHash));

        public void ExitedState(int stateHash) => StateExited?.Invoke(StateFor(stateHash));

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;

            if (stateHash == idleStateHash)
                state = AnimatorState.Idle;
            else if (stateHash == attackStateHash)
                state = AnimatorState.Attack;
            else if (stateHash == moveStateHash)
                state = AnimatorState.Walking;
            else if (stateHash == dieStateHash)
                state = AnimatorState.Died;
            else
                state = AnimatorState.Unknown;

            return state;
        }
    }
}