using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputs : MonoBehaviour, IInputGiver
    {
        public Vector2 MousePosition { get; private set; }

        public float Rotation { get; private set; }

        public bool Acceleration { get; private set; }

        public bool Fire { get; private set; }

        public bool Menu { get; private set; }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
            MousePosition = context.ReadValue<Vector2>();
        }

        public void OnRotation(InputAction.CallbackContext context)
        {
            Rotation = context.ReadValue<float>();
        }

        public void OnAcceleration(InputAction.CallbackContext context)
        {
            Acceleration = context.ReadValueAsButton();
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            Fire = context.ReadValueAsButton();
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            Menu = context.ReadValueAsButton();
        }
    }
}
