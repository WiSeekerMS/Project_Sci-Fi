using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        private void Awake()
        {
            if (playButton)
            {
                playButton.onClick.AddListener(OnPlay);
            }
            else
            {
                Debug.LogError("Play button is null");
            }
        }

        private void OnPlay()
        {
            if (SceneLoader.Instance)
            {
                SceneLoader.Instance.LoadScene(Enums.Scenes.SampleScene.ToString());
            }
            else
            {
                Debug.LogError("SceneLoader is not instance");
            }
        }
    }
}
