using UnityEngine;

namespace Scripts.Common
{
    public class TapEffect : MonoBehaviour
    {
        [SerializeField] private GameObject body;

        public Vector3 SetPosition
        {
            set => transform.position = value;
        }

        public void ResetEffect() { }
    }
}