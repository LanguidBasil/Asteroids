using System;
using UnityEngine;

using Project.Core.Objects;
using Project.Core.Spawners;
using Project.Core.Conf.SO;
using Project.Input;
using Project.Tools;

namespace Project.Managers
{
    public class UFOManager : MonoBehaviour, IMovementInput
    {
        public Vector2 Move { get; private set; }

        public Action Fire { get; set; }

        [SerializeField]
        private SceneInfoSO sceneInfo;
        [SerializeField]
        private Spawner ufoSpawner;
        [SerializeField]
        private Spawner playerSpawner;
        [SerializeField]
        private float spawnTimeAfterKill;
        [SerializeField]
        private float spawnHeightDelta;

        private Transform player;
        private float ufoSpawnTimer;

        private void Awake()
        {
            ufoSpawner.SetInputs(this);

            playerSpawner.OnSpawn += (object sender, SpawnArgs args) => { player = args.SpawnedObject.transform; };
            ufoSpawner.OnSpawn += (object sender, SpawnArgs args) => 
                                    {
                                        args.SpawnedObject.GetComponent<SpaceShip>().OnDestroy += (object sender, DeathArgs args) => { ufoSpawnTimer = Time.time + spawnTimeAfterKill; }; 
                                    };
        }

        private void Start()
        {
            ufoSpawnTimer = Time.time + spawnTimeAfterKill;
        }

        private void Update()
        {
            if (Time.time > ufoSpawnTimer)
            {
                ufoSpawner.Spawn(new Vector2(-sceneInfo.CameraBoundsExtents.x, UnityEngine.Random.Range(-spawnHeightDelta, spawnHeightDelta)), Quaternion.Euler(0, 0, 270));
                ufoSpawnTimer = Mathf.Infinity;
            }

            if (player != null)
            {
                Vector2 directionToPlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y).normalized;
                float angleBetweenLookAndMouse = Vector2.SignedAngle(Trigonometry.UnityDegreeToVector2(player.transform.eulerAngles.z), directionToPlayer);

                Move = new Vector2(-Mathf.Sign(angleBetweenLookAndMouse), 1);
            }
            else
            {
                Move = Vector2.up;
            }
        }
    }
}