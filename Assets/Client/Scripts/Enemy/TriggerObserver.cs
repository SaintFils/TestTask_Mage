using System;
using UnityEngine;

namespace Client.Scripts.Enemy
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> TriggerEnter;
        public event Action<Collider> TriggerExit;
        
        private void OnTriggerEnter(Collider coll) => TriggerEnter?.Invoke(coll);

        private void OnTriggerExit(Collider coll) => TriggerExit?.Invoke(coll);
    }
}