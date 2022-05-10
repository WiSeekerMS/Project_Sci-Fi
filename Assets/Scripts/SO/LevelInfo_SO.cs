using UnityEngine;

namespace Assets.Scripts.SO
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "ScriptableObjects/LevelInfo", order = 1)]
    public class LevelInfo_SO : ScriptableObject
    {
        [Header("Enemy")] 
        [SerializeField] private float enemyMoveSpeed;
        [SerializeField] private float EnemyFrequency;

        [Header("Other")] 
        [SerializeField] private int amountBonuses;
        [SerializeField] private int amountObstacles;
    }
}
