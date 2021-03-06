using Assets.Scripts.Items;

namespace Assets.Scripts.Factories
{
    public class BonusesFactory : InteractiveItemsFactory<Bonus>
    {
        protected override void OnCreateItem(Bonus item)
        {
            item.Destroyed = RemoveFromList;
            var tuple = items.Find(i => i.item == item);
            if (tuple.platformItem) tuple.platformItem.IsFree = false;
        }

        private void RemoveFromList(Bonus bonus)
        {
            var tuple = items.Find(t => t.item == bonus);
            if (tuple.item) items.Remove(tuple);
            if (tuple.platformItem) tuple.platformItem.IsFree = true;
        }
    }
}
