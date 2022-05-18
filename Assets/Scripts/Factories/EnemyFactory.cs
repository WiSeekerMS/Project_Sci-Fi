using System;

namespace Assets.Scripts.Factories
{
    public class EnemyFactory : InteractiveItemsFactory<Enemy>
    {
        public Action DidDamage;

        protected override void OnCreateItem(Enemy enemy)
        {
            enemy.CatchAction = CaughtPlayer;
            enemy.Destroyed = RemoveFromList;

            var tuple = items.Find(i => i.item == enemy);
            if (tuple.platformItem) tuple.platformItem.IsFree = false;
        }

        private void RemoveFromList(Enemy enemy)
        {
            var tuple = items.Find(t => t.item == enemy);
            if (tuple.item) items.Remove(tuple);
            if (tuple.platformItem) tuple.platformItem.IsFree = true;
        }

        private void CaughtPlayer(Enemy enemy)
        {
            DidDamage?.Invoke();
            enemy.DestroyMy();
        }
    }
}
