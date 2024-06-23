﻿using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Client.Scripts.Enemy
{ 
    [RequireComponent(typeof(Attack))]
    public class CheckAttackRange : MonoBehaviour
    {
        [SerializeField] private Attack attack;
        [SerializeField] private TriggerObserver triggerObserver;

        private void Start()
        {
            triggerObserver.TriggerEnter += TriggerEnter;
            triggerObserver.TriggerExit += TriggerExit;

            attack.DisableAttack();
        }

        private void OnDestroy()
        {
            triggerObserver.TriggerEnter -= TriggerEnter;
            triggerObserver.TriggerExit -= TriggerExit;
        }

        private void TriggerEnter(Collider obj)
        {
            attack.EnableAttack();
        }

        private void TriggerExit(Collider obj)
        {
            attack.DisableAttack();
        }
    }
}