using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputs : MonoBehaviour, IMovementInput
    {
        public Vector2 Look { get; private set; }

        public Vector2 Move { get; private set; }

        public Action Fire { get; set; }

        public Action Menu { get; set; }

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
            if (context.performed)
                Fire?.Invoke();
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            if (context.performed)
                Menu?.Invoke();
        }
    }
}
