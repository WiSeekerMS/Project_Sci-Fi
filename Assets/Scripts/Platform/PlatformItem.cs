using UnityEngine;

namespace Assets.Scripts.Platform
{
    public class PlatformItem : MonoBehaviour
    {
        private bool isFree = true;
        private Vector3 topBound;

        public bool IsFree
        {
            get => isFree;
            set => isFree = value;
        }

        public Vector3 Position => transform.position;
        public Vector3 Scale => transform.localScale;

        public Vector3 TopBound => topBound;

        public void Init()
        {
            topBound = CalculateTopBound();
        }

        private Vector3 CalculateTopBound()
        {
            var position = Position;
            position.y += Scale.y / 2f;
            return position;
        }
    }
}
