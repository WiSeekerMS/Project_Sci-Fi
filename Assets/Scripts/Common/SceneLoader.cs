using Assets.Scripts.Common;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance;
        private Coroutine sceneLoadCoroutine;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public void LoadScene(string sceneName)
        {
            sceneLoadCoroutine = StartCoroutine(LoadSceneCor(sceneName));
        }

        private IEnumerator LoadSceneCor (string sceneName)
        {
            var sceneLoadingOperation = SceneManager.LoadSceneAsync(sceneName);
            sceneLoadingOperation.allowSceneActivation = false;
            while (sceneLoadingOperation.progress < 0.9f)
                yield return null;

            sceneLoadingOperation.allowSceneActivation = true;
            while (!sceneLoadingOperation.isDone)
                yield return null;
        }

        public void ReturnToMainScene()
        {
            LoadScene(Enums.Scenes.MainScene.ToString());
        }
    }
}
