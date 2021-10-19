using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovementInput : MonoBehaviour, IMovementInput
    {
        public Vector2 LookPosition { get; private set; }

        public Vector2 Navigation { get; private set; }

        public bool Fire { get; private set; }

        public bool Submit { get; private set; }

        public bool Cancel { get; private set; }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
            LookPosition = context.ReadValue<Vector2>();
        }

        public void OnNavigation(InputAction.CallbackContext context)
        {
            Navigation = context.ReadValue<Vector2>();
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            Fire = context.ReadValueAsButton();
        }

        public void OnSubmit(InputAction.CallbackContext context)
        {
            Submit = context.ReadValueAsButton();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            Cancel = context.ReadValueAsButton();
        }
    }
}
