using Assets.Scripts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Platform
{
    [Serializable]
    public class Area
    {
        [SerializeField] private Enums.AreaType type;
        [SerializeField] private List<PlatformItem> items;

        public Enums.AreaType Type => type;
        public List<PlatformItem> Items => items;

        public void Init(List<PlatformItem> items)
        {
            this.items = items;
        }

        public PlatformItem GetFreePlatformItem()
        {
            var freeItems = items.Where(i => i.IsFree).ToList();
            var randomIndex = UnityEngine.Random.Range(0, freeItems.Count);
            return freeItems[randomIndex];
        }
    }
}
