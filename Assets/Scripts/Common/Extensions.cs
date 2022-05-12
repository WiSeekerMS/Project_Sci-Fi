using Assets.Scripts.Platform;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Common
{
    public static class Extensions
    {
        public static PlatformItem GetRandomFreeItem(this List<PlatformItem> list)
        {
            var freeItems = list.Where(i => i.IsFree).ToList();
            var index = UnityEngine.Random.Range(0, freeItems.Count);
            var item = freeItems[index];
            return item;
        }
    }
}
