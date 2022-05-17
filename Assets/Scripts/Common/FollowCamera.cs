using UnityEngine;

namespace Assets.Scripts
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField, Range(0.1f, 5f)] private float smoothSpeed;

        private void FixedUpdate()
        {
            var cameraPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
