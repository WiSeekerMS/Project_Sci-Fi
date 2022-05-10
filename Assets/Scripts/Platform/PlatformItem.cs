using UnityEngine;

namespace Assets.Scripts.Platform
{
    public class PlatformItem : MonoBehaviour
    {
        private bool isFree = true;

        public bool IsFree
        {
            get => isFree;
            set => isFree = value;
        }

        public Vector3 Position => transform.position;
    }
}
