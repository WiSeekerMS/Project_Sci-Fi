using Assets.Scripts.BaseClasses;
using Assets.Scripts.Common;
using Assets.Scripts.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class InteractiveItemsFactory<T> : GenericFactory<T> where T : MonoBehaviour
    {
        [SerializeField] private Platform.Platform platform;
        [SerializeField] private Enums.AreaType spawnArea;
        [SerializeField] private Timer timer;
        [SerializeField] private Transform parent;

        protected List<(T item, PlatformItem platformItem)> items;
        protected Vector2 timeValues;
        protected int maxAmount;
        protected Area area;

        protected virtual void OnCreateItem(T item){}

        public void Init(int startAmount, int maxAmount, Vector2 timeValues)
        {
            this.maxAmount = maxAmount;
            this.timeValues = timeValues;
            area = platform.GetArea(spawnArea);
            if (area == null)
            {
                Debug.LogError("Could not find area");
                return;
            }

            items = new List<(T item, PlatformItem platformItem)>();
            CreateItem(startAmount);
            StartCoroutine(SpawnBonusCor());
        }

        private IEnumerator SpawnBonusCor()
        {
            while (true)
            {
                while (items?.Count >= maxAmount)
                    yield return null;

                var time = Random.Range(timeValues.x, timeValues.y);
                yield return timer.TimerCor(time, () => CreateItem(1));
            }
        }

        private void CreateItem(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var platformItem = area.GetFreePlatformItem();
                if (platformItem == null)
                {
                    Debug.LogError("No free platform item");
                    return;
                }

                var item = GetNewInstance(parent).GetComponent<T>();
                item.transform.position = platformItem.TopBound;
                OnCreateItem(item);

                items.Add((item, platformItem));
            }
        }
    }
}
