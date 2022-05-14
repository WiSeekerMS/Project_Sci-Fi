using Assets.Scripts.Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Platform
{
    [RequireComponent(typeof(PlatformCreator))]
    public class Platform : MonoBehaviour
    {
        private PlatformCreator platformCreator;
        private List<PlatformItem> itemsList;

        public event Action Ready;

        public void Init()
        {
            platformCreator = GetComponent<PlatformCreator>();
            itemsList = new List<PlatformItem>();

            var creatorTransform = platformCreator.transform;
            var itemsCount = creatorTransform.childCount;

            for (int i = 0; i < itemsCount; i++)
            {
                var child = creatorTransform.GetChild(i);
                var item = child.GetComponent<PlatformItem>();
                
                if (item)
                {
                    item.Init();
                    itemsList.Add(item);
                }
            }

            Ready?.Invoke();
        }

        public Area GetArea(Enums.AreaType type)
        {
            return platformCreator.GetArea(type);
        }
    }
}
