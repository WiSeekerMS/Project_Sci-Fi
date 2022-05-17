using Assets.Scripts.BaseClasses;
using Assets.Scripts.Common;
using Assets.Scripts.Items;
using Assets.Scripts.Platform;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class ObstacleFactory : GenericFactory<Obstacle>
    {
        [SerializeField] private Platform.Platform platform;
        [SerializeField] private Enums.AreaType spawnArea;
        [SerializeField] private Transform parent;
        private Area area;

        public void Init(int amount)
        {
            area = platform.GetArea(spawnArea);
            if (area == null)
            {
                Debug.LogError("Could not find area");
                return;
            }

            CreateObstacles(amount);
        }

        private void CreateObstacles(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var platformItem = area.GetFreePlatformItem();
                if (platformItem == null)
                {
                    Debug.LogError("No free platform item");
                    return;
                }

                var obstacle = GetNewInstance(parent).GetComponent<Obstacle>();
                obstacle.transform.position = platformItem.TopBound;
                platformItem.IsFree = false;
            }
        }
    }
}