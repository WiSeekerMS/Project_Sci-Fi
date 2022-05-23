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
        [SerializeField] private float rotateSpeed;
        private float distanceToTarget = 0.1f;
        private float maxDegreeForRotation = 120f;
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
            
            rb.velocity = Vector3.zero;
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }

        public void MoveTo(Vector3 target)
        {
            StopAllCoroutines();
            rb.velocity = Vector3.zero;
            StartCoroutine(MoveToCor(target));
        }

        private IEnumerator MoveToCor(Vector3 target)
        {
            //animationController.SetTurnLeftAnimation();
            yield return RotateCor(target);
            animationController.SetRunAnimation();
            
            yield return MoveCor(target);
            animationController.SetIdleAnimation();
        }

        private IEnumerator RotateCor(Vector3 target) 
        {
            Vector3 relativePos = target - transform.position;
            var to = Quaternion.LookRotation(relativePos);
            var angle = Quaternion.Angle(transform.rotation, to);

            if(angle > maxDegreeForRotation)
            {
                transform.LookAt(target);
                yield break;
            }

            while (Mathf.Abs(Quaternion.Dot(transform.rotation, to)) < 0.999999f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, to, 
                    rotateSpeed * Time.deltaTime);
                yield return null;
            }
        }

        private IEnumerator MoveCor(Vector3 target)
        {
            rb.velocity = transform.forward * moveSpeed;
            while (Vector3.Distance(transform.position, target) > distanceToTarget)
                yield return null;

            rb.velocity = Vector3.zero;
        }
    }
}
