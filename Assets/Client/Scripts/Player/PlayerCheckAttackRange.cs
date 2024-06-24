using Client.Scripts.Logic;
using UnityEngine;

namespace Client.Scripts.Player
{
    public class PlayerCheckAttackRange : MonoBehaviour
    {
        [SerializeField] private PlayerAttack attack;
        [SerializeField] private TriggerObserver triggerObserver;

        private void Start()
        {
            //triggerObserver.TriggerEnter += TriggerEnter;
            //triggerObserver.TriggerExit += TriggerExit;

           // attack.DisableAttack();
        }
        
        private void OnDestroy()
        {
            //triggerObserver.TriggerEnter -= TriggerEnter;
            //triggerObserver.TriggerExit -= TriggerExit;
        }

        // private void TriggerEnter(Collider obj)
        // {
        //     attack.EnableAttack(obj);
        // }

        // private void TriggerExit(Collider obj)
        // {
        //     attack.DisableAttack();
        // }
    }
}