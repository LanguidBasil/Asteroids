using System.Collections.Generic;
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

        private List<Renderer> playerRenderers;
        private float blinkingEndTime;
        private float nextBlinkTimer;

        private void Awake()
        {
            playerRenderers = new List<Renderer>();

            playerSpawner.OnSpawn += (object sender, SpawnArgs args) => 
                                    {
                                        var so = (SpaceShipSO)args.SpawnedObject.GetComponent<SpaceShip>().SO;
                                        blinkingEndTime = Time.time + so.InvincibiltyTime;
                                        foreach (var renderer in args.SpawnedObject.GetComponentsInChildren<Renderer>())
                                        {
                                            playerRenderers.Add(renderer);
                                        }
                                    };
        }

        private void Update()
        {
            if (playerRenderers.Count <= 0)
                return;

            if (blinkingEndTime > Time.time)
            {   
                if (Time.time > nextBlinkTimer)
                {
                    foreach (var renderer in playerRenderers)
                        renderer.enabled = !renderer.enabled;
                    nextBlinkTimer = Time.time + intervals;
                }
            }
            else
            {
                foreach (var renderer in playerRenderers)
                    renderer.enabled = true;
                playerRenderers.Clear();
            }
        }
    }
}