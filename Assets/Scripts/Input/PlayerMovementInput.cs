using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovementInput : MonoBehaviour, IMovementInput
    {
        public Vector2 LookPosition { get; private set; }

        public float Rotation { get; private set; }

        public bool Acceleration { get; private set; }

        public bool Fire { get; private set; }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
            LookPosition = context.ReadValue<Vector2>();
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
    }
}
