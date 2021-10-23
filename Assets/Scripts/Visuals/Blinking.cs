using UnityEngine;

using Project.Core.Spawners;
using Project.Core.Objects;

namespace Project.Visuals
{
    public class Blinking : MonoBehaviour
    {
        [SerializeField]
        private ControllerSpawner playerSpawner;
        [Tooltip("Intervals in seconds between changing states")]
        [SerializeField]
        private float intervals;

        private Renderer playerRenderer;
        private float blinkingEndTime;
        private float nextBlinkTimer;

        private void Awake()
        {
            playerSpawner.OnSpawn += (object sender, SpawnArgs args) => 
                                    { 
                                        blinkingEndTime = Time.time + args.SpawnedObject.GetComponent<SpaceShip>().SO.InvincibiltyTime;
                                        playerRenderer = args.SpawnedObject.GetComponent<Renderer>();
                                    };
        }

        private void Update()
        {
            if (playerRenderer == null)
                return;

            if (blinkingEndTime > Time.time)
            {   
                if (Time.time > nextBlinkTimer)
                {
                    playerRenderer.enabled = !playerRenderer.enabled;
                    nextBlinkTimer = Time.time + intervals;
                }
            }
            else
            {
                playerRenderer.enabled = true;
                playerRenderer = null;
            }
        }
    }
}