using UnityEngine;

namespace Assets.Scripts
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;

        private void Awake()
        {
            Instance = this;
        }
    }
}
