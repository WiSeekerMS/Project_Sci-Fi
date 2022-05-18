using System;
using UnityEngine;

namespace Assets.Scripts.Common
{
    [RequireComponent(typeof(Collider))]
    public class TriggerHandler : MonoBehaviour
    {
        private Collider triggerCollider;
        public event Action<Collider> EnterEvent;

        private void Start()
        {
            triggerCollider = GetComponent<Collider>();
            triggerCollider.isTrigger = true;
        }

        public void OnTriggerEnter(Collider other)
        {
            EnterEvent?.Invoke(other);
        }
    }
}
