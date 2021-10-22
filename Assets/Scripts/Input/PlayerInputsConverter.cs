using System;
using UnityEngine;

using Project.Core.Spawners;
using Project.Tools;

namespace Project.Input
{
    public class PlayerInputsConverter : MonoBehaviour, IMovementInput
    {
        [SerializeField]
        private PlayerInputs input;
        [SerializeField]
        private ControllerSpawner playerSpawner;
        [SerializeField]
        private new Camera camera;

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
            if (player != null)
            {
                Vector2 directionToMouse = ScreenPositionToDirection(player.transform.position, input.Mouse, new Vector2(camera.pixelWidth, camera.pixelHeight));
                float angleBetweenLookAndMouse = Vector2.SignedAngle(Trigonometry.UnityDegreeToVector2(player.transform.eulerAngles.z), directionToMouse);

                Move = new Vector2(-Mathf.Sign(angleBetweenLookAndMouse), input.Move.y);
            }
        }

        private Vector2 ScreenPositionToDirection(Vector2 from, Vector2 screenPosition, Vector2 cameraSizes)
        {
            return new Vector2(screenPosition.x - cameraSizes.x / 2 - from.x,
                               screenPosition.y - cameraSizes.y / 2 - from.y).normalized;
        }
    }
}