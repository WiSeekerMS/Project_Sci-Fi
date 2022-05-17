using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Controllers
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private TriggerHandler triggerHandler;
        [SerializeField] private float distanceToTarget = 0.5f;
        
        private NavMeshAgent agent;
        private Vector3 targetPoint;
        private bool isMoving;

        public TriggerHandler TriggerHandler => triggerHandler;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.autoBraking = false;
        }

        public void MoveToPoint(Vector3 point)
        {
            targetPoint = point;
            agent.SetDestination(targetPoint);
            isMoving = true;
        }

        private void Update()
        {
            if (isMoving && Vector3.Distance(targetPoint, transform.position) <= distanceToTarget)
            {
                isMoving = false;
                agent.ResetPath();
            }
        }
    }
}
