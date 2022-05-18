using Assets.Scripts.Common;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterAnimation animationController;
        [SerializeField] private TriggerHandler triggerHandler;
        [SerializeField] private float moveSpeed;
        private float distanceToTarget = 0.3f;
        private Rigidbody rb;

        public TriggerHandler TriggerHandler => triggerHandler;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void OnReset() 
        {
            StopAllCoroutines();
            animationController.SetIdleAnimation();
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }

        public void MoveTo(Vector3 target)
        {
            StopAllCoroutines();
            transform.LookAt(target);
            animationController.SetRunAnimation();
            StartCoroutine(MoveCor(target, () => animationController.SetIdleAnimation()));
        }

        private IEnumerator MoveCor(Vector3 target, System.Action stopMove)
        {
            while (Vector3.Distance(transform.position, target) > distanceToTarget)
            {
                var direction = target - transform.position;
                var moveVector = new Vector3(direction.x, 0f, direction.z);
                rb.MovePosition(transform.position + moveVector * moveSpeed * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }

            stopMove?.Invoke();
        }
    }
}
