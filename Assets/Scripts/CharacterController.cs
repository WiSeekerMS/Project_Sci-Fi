using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterController : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Vector3 targetPoint;
        private bool isMoving;

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
            if (isMoving && Vector3.Distance(targetPoint, transform.position) <= 0.5f)
            {
                isMoving = false;
                agent.ResetPath();
            }
        }
    }
}
