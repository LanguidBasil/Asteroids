using UnityEngine;

using Project.Core.Conf.SO;
using Project.Core.Spawners;
using Project.Core.Objects;

namespace Project.Visuals
{
    public class Blinking : MonoBehaviour
    {
        [SerializeField]
        private Spawner playerSpawner;
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
                                        var so = (SpaceShipSO)args.SpawnedObject.GetComponent<SpaceShip>().SO;
                                        blinkingEndTime = Time.time + so.InvincibiltyTime;
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