using Assets.Scripts.BaseClasses;
using Assets.Scripts.Common;
using Assets.Scripts.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class BonusesFactory : GenericFactory<Bonus>
    {
        [SerializeField] private Platform.Platform platform;
        [SerializeField] private Enums.AreaType spawnArea;
        [SerializeField] private Timer timer;
        [SerializeField] private Transform parent;

        private List<Bonus> bonuses;
        private Vector2 timeValues;
        private int maxAmount;
        private Area area;

        public void Init(int startAmount, int maxAmount, Vector2 timeValues)
        {
            this.maxAmount = maxAmount;
            this.timeValues = timeValues;
            area = platform.GetArea(spawnArea);
            if (area == null)
            {
                Debug.LogError("");
                return;
            }

            bonuses = new List<Bonus>();
            CreateBonuses(startAmount);
            StartCoroutine(SpawnBonusCor());
        }

        private IEnumerator SpawnBonusCor()
        {
            while (true)
            {
                if(bonuses?.Count >= maxAmount) yield return null;
                var time = Random.Range(timeValues.x, timeValues.y);
                yield return timer.TimerCor(time, () => CreateBonuses(1));
            }
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
                bonuses.Add(bonus);
            }
        }
    }
}
