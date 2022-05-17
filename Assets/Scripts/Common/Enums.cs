using UnityEngine;

namespace Assets.Scripts.Common
{
    public class Enums : MonoBehaviour
    {
        public enum Scenes
        {
            MainScene, SampleScene
        }

        public enum AreaType
        {
            EnemySpawn, BonusesSpawn
        }

        public enum ItemType
        {
            Bonus, Enemy
        }
    }
}
