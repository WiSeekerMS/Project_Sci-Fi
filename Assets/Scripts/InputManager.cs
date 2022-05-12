using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;
        private TouchControls touchController;
        private Vector2 lastTapPosition;
        public event Action<Vector2> TapPosition;

        private Vector2 SetTapPosition
        {
            set
            {
                lastTapPosition = value;
                TapPosition?.Invoke(lastTapPosition);
            }
        }

        public Vector2 LastTapPositionWithScreen => lastTapPosition;

        private void Awake()
        {
            Instance = this;
            touchController = new TouchControls();
        }

        private void OnEnable()
        {
            touchController.Enable();
        }

        private void OnDestroy()
        {
            touchController.Disable();
        }

        private void Start()
        {
            touchController.Main.TouchTap.performed += OnTouchPoint;
            touchController.Main.MouseClick.performed += OnMouseClick;
        }

        private void OnTouchPoint(InputAction.CallbackContext context)
        {
            SetTapPosition = touchController.Main.TouchPosition.ReadValue<Vector2>();
        }

        private void OnMouseClick(InputAction.CallbackContext context)
        {
            SetTapPosition = touchController.Main.MousePosition.ReadValue<Vector2>();
        }
    }
}
