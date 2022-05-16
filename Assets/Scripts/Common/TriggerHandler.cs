using UnityEngine;

namespace Assets.Scripts.Common
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class TriggerHandler : MonoBehaviour
    {
        private Rigidbody rb;
        private Collider triggerCollider;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            triggerCollider = GetComponent<Collider>();
        }

        private void Start()
        {
            rb.useGravity = false;
            triggerCollider.isTrigger = true;
        }
    }
}
