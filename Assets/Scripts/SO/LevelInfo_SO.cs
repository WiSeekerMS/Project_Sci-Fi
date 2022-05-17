using UnityEngine;

namespace Assets.Scripts.SO
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "ScriptableObjects/LevelInfo", order = 1)]
    public class LevelInfo_SO : ScriptableObject
    {
        [Header("> Other <")]
        [SerializeField] private int playerHP;
        [SerializeField] private int amountObstacles;

        [Header("> Enemy <")]
        [SerializeField] private int enemyAmount;
        [SerializeField] private int maxEnemyAmount;
        [SerializeField] private Vector2 spawnEnemyTime;

        [Header("> Bonuses <")] 
        [SerializeField] private int startAmountBonuses;
        [SerializeField] private int maxAmountBonuses;
        [SerializeField] private Vector2 spawnBonusesTime;

        public int PlayerHP => playerHP;
        public int AmountObstacles => amountObstacles;

        public int EnemyAmount => enemyAmount;
        public int MaxEnemyAmount => maxEnemyAmount;
        public Vector2 SpawnEnemyTimeValues => spawnEnemyTime;
        public int StartAmountBonuses => startAmountBonuses;
        public int MaxAmountBonuses => maxAmountBonuses;
        public Vector2 SpawnBonusesTimeValues => spawnBonusesTime;
    }
}
