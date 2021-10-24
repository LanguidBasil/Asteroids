using System;
using UnityEngine;
using UnityEngine.InputSystem;

using Project.Core.Spawners;
using Project.Tools;

namespace Project.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputs : MonoBehaviour, IMovementInput
    {
        public Vector2 Move { get; private set; }

        public Action Fire { get; set; }

        public Action Menu { get; set; }

        [SerializeField]
        private Spawner spawner;
        [SerializeField]
        private PlayerInput unityPlayerInput;
        [SerializeField]
        private string keyboardControlSchemeName;
        [SerializeField]
        private string keyboardAndMouseControlSchemeName;

        protected Transform user;
        protected Vector2 lookPoint;
        protected Vector2 moveBuffer;
        protected bool lookWithMouse;

        protected void Awake()
        {
            spawner.SetInputs(this);
            spawner.OnSpawn += (object sender, SpawnArgs args) => { user = args.SpawnedObject.transform; };

            RethinkControlScheme(unityPlayerInput.currentControlScheme);
        }

        protected void Update()
        {
            if (user == null)
                return;

            if (lookWithMouse)
            {
                Vector2 directionToMouse = new Vector2(lookPoint.x - user.position.x, lookPoint.y - user.position.y).normalized;
                float angleBetween = Vector2.SignedAngle(Trigonometry.UnityDegreeToVector2(user.eulerAngles.z), directionToMouse);

                Move = new Vector2(-Mathf.Sign(angleBetween), moveBuffer.y);
            }
            else
            {
                Move = moveBuffer;
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            lookPoint = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            moveBuffer = context.ReadValue<Vector2>();
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

        public void RethinkControlScheme(string newControlScheme)
        {
            if (newControlScheme == keyboardAndMouseControlSchemeName)
            {
                lookWithMouse = true;
            }
            else if (newControlScheme == keyboardControlSchemeName)
            {
                lookWithMouse = false;
            }
            else
            {
                Debug.Log($"Unknown control scheme on {gameObject.name}");
            }
        }
    }
}
