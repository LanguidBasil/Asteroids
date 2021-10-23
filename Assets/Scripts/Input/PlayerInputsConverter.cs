using System;
using UnityEngine;
using UnityEngine.InputSystem;

using Project.Core.Spawners;
using Project.Tools;

namespace Project.Input
{
    public class PlayerInputsConverter : MonoBehaviour, IMovementInput
    {
        [SerializeField]
        private PlayerInput unityPlayerInput;
        [SerializeField]
        private PlayerInputs input;
        [SerializeField]
        private ControllerSpawner playerSpawner;
        [Space(8)]
        [SerializeField]
        private string keyboardAndMouseControlSchemeName;

        private GameObject player;

        public Vector2 Move { get; private set; }

        public Action Fire { get; set; }

        public Action Menu { get; set; }

        private void Awake()
        {
            input.Fire += () => { Fire?.Invoke(); };
            input.Menu += () => { Menu?.Invoke(); };

            playerSpawner.OnSpawn += (object sender, SpawnArgs args) => { player = args.SpawnedObject; };
        }

        private void Update()
        {
            if (player == null)
                return;

            if (unityPlayerInput.currentControlScheme == keyboardAndMouseControlSchemeName)
            {
                Vector2 directionToMouse = ScreenPositionToDirection(Camera.main.WorldToScreenPoint(player.transform.position), input.Mouse);
                float angleBetweenLookAndMouse = Vector2.SignedAngle(Trigonometry.UnityDegreeToVector2(player.transform.eulerAngles.z), directionToMouse);

                Move = new Vector2(-Mathf.Sign(angleBetweenLookAndMouse), input.Move.y);
            }
            else
            {
                Move = input.Move;
            }
        }

        private Vector2 ScreenPositionToDirection(Vector2 screenFromPosition, Vector2 screenToPosition)
        {
            return new Vector2(screenToPosition.x - screenFromPosition.x,
                               screenToPosition.y - screenFromPosition.y).normalized;
        }
    }
}