using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class InputManager : MonoBehaviour
    {
        //private InputActionAsset touchControlls;
        public static InputManager Instance;

        private void Awake()
        {
            Instance = this;
            //touchControlls = new InputActionAsset();
            //touchControl
        }

        private void OnTap(InputAction.CallbackContext context){}
    }
}
