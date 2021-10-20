using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovementInput : MonoBehaviour, IMovementInput
    {
        public Vector2 Look { get; private set; }

        public Vector2 Move { get; private set; }

        public bool Fire { get; private set; }

        public bool Menu { get; private set; }

        public void OnLook(InputAction.CallbackContext context)
        {
            Look = context.ReadValue<Vector2>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<Vector2>();
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
