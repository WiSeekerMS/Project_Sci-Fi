using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class PatrolPoints : MonoBehaviour
    {
        public static PatrolPoints Instance;
        private List<Vector3> points;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void OnEnable()
        {
            points = new List<Vector3>();
            for (int i = 0; i < transform.childCount; i++)
            {
                points.Add(transform.GetChild(i).position);
            }
        }

        public Vector3 GetRandomPoint()
        {
            if (points == null || !points.Any())
            {
                return Vector3.zero;
            }

            return points[Random.Range(0, points.Count)];
        }
    }
}
