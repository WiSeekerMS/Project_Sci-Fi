using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class EnemyFactory : InteractiveItemsFactory<Enemy>
    {
        protected override void OnCreateItem(Enemy item)
        {
            item.Destroyed = RemoveFromList;
            var tuple = items.Find(i => i.item == item);
            if (tuple.platformItem) tuple.platformItem.IsFree = false;
        }

        private void RemoveFromList(Enemy enemy)
        {
            var tuple = items.Find(t => t.item == enemy);
            if (tuple.item) items.Remove(tuple);
            if (tuple.platformItem) tuple.platformItem.IsFree = true;
        }
    }
}
