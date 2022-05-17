using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.BaseClasses
{
    public abstract class UIController : MonoBehaviour
    {
        [SerializeField] private Button returnToMainMenuButton;

        private void Awake()
        {
            if (returnToMainMenuButton)
            {
                returnToMainMenuButton.onClick.AddListener(ReturnToMainMenu);
            }
            else
            {
                Debug.LogError("Return to Main Menu button is null");
            }
        }

        private void ReturnToMainMenu()
        {
            if (SceneLoader.Instance)
            {
                SceneLoader.Instance.ReturnToMainScene();
            }
            else
            {
                Debug.LogError("SceneLoader is not instance");
            }
        }
    }
}
