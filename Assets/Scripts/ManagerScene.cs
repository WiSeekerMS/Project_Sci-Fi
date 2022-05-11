using Assets.Scripts.SO;
using UnityEngine;

namespace Assets.Scripts
{
    public class ManagerScene : MonoBehaviour
    {
        [SerializeField] private Platform.Platform platform;
        [SerializeField] private LevelInfo_SO levelInfo;

        private void Awake()
        {
            platform.Ready += OnPlatformReady;
        }

        private void OnDestroy()
        {
            platform.Ready -= OnPlatformReady;
        }

        private void Start()
        {
            platform.Init();
        }

        public void ReturnToMainScene()
        {
            SceneLoader.Instance?.LoadScene("MainScene");
        }

        private void OnPlatformReady(){}
    }
}
