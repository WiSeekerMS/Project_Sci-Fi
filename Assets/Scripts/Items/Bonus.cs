using Assets.Scripts.Common;
using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Bonus : MonoBehaviour, IInteractiveItem
    {
        [SerializeField] private Enums.ItemType itemType;
        public Action<Bonus> Destroyed;
        public Enums.ItemType GetItemType => itemType;
        
        public void DestroyMy()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }
    }
}
