using Assets.Scripts.BaseClasses;
using Assets.Scripts.Factories;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class SampleGameController : GameController
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private CharacterController character;
        [SerializeField] private BonusesFactory bonusesFactory;
        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private ObstacleFactory obstacleFactory;
        
        protected override void OnAwake()
        {
            if (inputManager) inputManager.TapPosition += OnTap;
            if (character && character.TriggerHandler)
                character.TriggerHandler.EnterEvent += OnTriggerCalled;
        }

        protected override void OnStart()
        {
            overlayUI.SetHealt(levelInfo.PlayerHP);

            bonusesFactory.Init(levelInfo.StartAmountBonuses,
                levelInfo.MaxAmountBonuses, levelInfo.SpawnBonusesTimeValues);

            enemyFactory.Init(levelInfo.EnemyAmount,
                levelInfo.MaxEnemyAmount, levelInfo.SpawnEnemyTimeValues);

            enemyFactory.DidDamage = OnDamage;
            obstacleFactory.Init(levelInfo.AmountObstacles);
        }

        protected override void OnRestartLevel()
        {
            character.OnReset();
            overlayUI.SetHealt(levelInfo.PlayerHP);
            overlayUI.ChangeBonusCount(0);
            overlayUI.ChangeEnemyCount(0);
        }

        protected override void BeforeDestroy()
        {
            if (inputManager) inputManager.TapPosition -= OnTap;
            if (character && character.TriggerHandler)
                character.TriggerHandler.EnterEvent -= OnTriggerCalled;
        }

        private void OnTap(Vector2 value)
        {
            var ray = Camera.main.ScreenPointToRay(value);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, layerMask))
            {
                character.MoveTo(hit.point);
            }
        }

        private void OnDamage()
        {
            var hp = overlayUI.CurrentHPCount;
            if (--hp > 0)
            {
                overlayUI.SetHealt(hp);
                overlayUI.ChangeEnemyCount(overlayUI.CurrentEnemyCount + 1);
            }
            else
            {
                OnRestartLevel();
            }
        }

        private void OnTriggerCalled(Collider other)
        {
            var monoBehavior = other.gameObject.GetComponent<MonoBehaviour>();
            if (monoBehavior && monoBehavior is IInteractiveItem item)
            {
                DefineAction(item);
            }
        }

        private void DefineAction(IInteractiveItem item)
        {
            switch (item.GetItemType)
            {
                case Common.Enums.ItemType.Bonus:
                    overlayUI.ChangeBonusCount(overlayUI.CurrentBonusCount + 1);
                    item.DestroyMy();
                    break;
            }
        }
    }
}
