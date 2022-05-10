using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Platform
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private PlatformCreator platformCreator;
        private List<PlatformItem> itemsList;

        public event Action Ready;

        public void Init()
        {
            itemsList = new List<PlatformItem>();
            var creatorTransform = platformCreator.transform;
            var itemsCount = creatorTransform.childCount;

            for (int i = 0; i < itemsCount; i++)
            {
                var child = creatorTransform.GetChild(i);
                var item = child.GetComponent<PlatformItem>();
                if (item) itemsList.Add(item);
            }

            Ready?.Invoke();
        }

        public PlatformItem GetRandomFreeItem()
        {
            if (itemsList == null || !itemsList.Any())
            {
                Debug.Log("");
                return null;
            }

            var freeItems = itemsList.Where(i => i.IsFree).ToList();
            var index = UnityEngine.Random.Range(0, freeItems.Count);
            var item = freeItems[index];
            item.IsFree = false;
            return item;
        }
    }
}
