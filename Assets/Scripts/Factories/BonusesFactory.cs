using Assets.Scripts.BaseClasses;
using Assets.Scripts.Common;
using Assets.Scripts.Platform;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class BonusesFactory : GenericFactory<Bonus>
    {
        [SerializeField] private Platform.Platform platform;
        [SerializeField] private Enums.AreaType spawnArea;
        [SerializeField] private Timer timer;
        [SerializeField] private Transform parent;
        
        private int maxAmount;
        private Area area;

        public void Init(int startAmount, int maxAmount)
        {
            this.maxAmount = maxAmount;
            area = platform.GetArea(spawnArea);
            if (area == null)
            {
                Debug.LogError("");
                return;
            }

            CreateBonuses(startAmount);
            //timer.Init();
        }

        private void CreateBonuses(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var platformItem = area.GetFreePlatformItem();
                if (platformItem == null)
                {
                    Debug.LogError("");
                    return;
                }

                var bonus = GetNewInstance(parent).GetComponent<Bonus>();
                bonus.transform.position = platformItem.TopBound;
                platformItem.IsFree = false;
            }
        }
    }
}
