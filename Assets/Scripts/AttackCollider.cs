using System;
using UnityEngine;

namespace FortyWorks.Player
{
    [RequireComponent(typeof(Collider))]
    public class AttackCollider : MonoBehaviour
    {
        public bool Triggering { get; set; } = false;
        public BaseBehaviour TriggeringObject { get; set; }

        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        public void OnEnable()
        {
            Reset();
            _collider.enabled = true;
        }

        public void OnDisable()
        {
            Reset();
        }

        public void Reset()
        {
            Triggering = false;
            TriggeringObject = null;
            _collider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            Triggering = true;
            TriggeringObject = other.GetComponent<BaseBehaviour>();
        }

        public void OnTriggerExit(Collider other)
        {
            Reset();
        }
    }
}