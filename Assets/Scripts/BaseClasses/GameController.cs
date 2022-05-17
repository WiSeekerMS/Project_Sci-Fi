using Assets.Scripts.Controllers;
using Assets.Scripts.SO;
using UnityEngine;

namespace Assets.Scripts.BaseClasses
{
    public abstract class GameController : MonoBehaviour
    {
        [SerializeField] protected Platform.Platform platform;
        [SerializeField] protected LevelInfo_SO levelInfo;
        [SerializeField] private OverlayUI overlayUIPrefab;
        protected InputManager inputManager;
        protected OverlayUI overlayUI;

        protected abstract void OnAwake();
        protected abstract void OnStart();
        protected abstract void OnRestartLevel();
        protected abstract void BeforeDestroy();

        private void Awake()
        {
            platform.Ready += OnPlatformReady;
            inputManager = InputManager.Instance;
            overlayUI = Instantiate(overlayUIPrefab);
            OnAwake();
        }

        private void OnDestroy()
        {
            platform.Ready -= OnPlatformReady;
            BeforeDestroy();
        }

        private void Start()
        {
            platform.Init();
            OnStart();
        }

        private void RestartLevel()
        {

        }

        protected virtual void OnPlatformReady(){}
    }
}
