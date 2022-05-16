using Assets.Scripts.Factories;
using Assets.Scripts.SO;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Platform.Platform platform;
        [SerializeField] private LevelInfo_SO levelInfo;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private CharacterController character;
        [SerializeField] private BonusesFactory bonusesFactory;
        private InputManager inputManager;

        private void Awake()
        {
            platform.Ready += OnPlatformReady;
            inputManager = InputManager.Instance;
            if (inputManager) inputManager.TapPosition += OnTap;
        }

        private void OnDestroy()
        {
            platform.Ready -= OnPlatformReady;
            if (inputManager) inputManager.TapPosition -= OnTap;
        }

        private void Start()
        {
            platform.Init();
            bonusesFactory.Init(levelInfo.StartAmountBonuses, 
                levelInfo.MaxAmountBonuses, levelInfo.SpawnBonusesTimeValues);
        }

        public void OnReturnToMainScene()
        {
            SceneLoader.Instance?.LoadScene("MainScene");
        }

        private void OnPlatformReady(){}

        private void OnTap(Vector2 value)
        {
            var ray = Camera.main.ScreenPointToRay(value);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, layerMask))
            {
                character.MoveToPoint(hit.point);
            }
        }
    }
}
