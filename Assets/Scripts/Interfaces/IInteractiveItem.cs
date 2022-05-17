using Assets.Scripts.Common;

namespace Assets.Scripts.Interfaces
{
    public interface IInteractiveItem
    {
        public Enums.ItemType GetItemType { get; }
        public void DestroyMy();
    }
}
