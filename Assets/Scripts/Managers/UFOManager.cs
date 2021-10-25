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
        [SerializeField]
        private float timeBetweenFire;

        private SpaceShip player;
        private SpaceShip ufo;
        private float ufoSpawnTimer;
        private float ufoFireTimer;

        private void Awake()
        {
            ufoSpawner.SetInputs(this);
            ufoSpawnTimer = Mathf.Infinity;
            ufoFireTimer = Mathf.Infinity;

            playerSpawner.OnSpawn += (object sender, SpawnArgs args) => { player = args.SpawnedObject.GetComponent<SpaceShip>(); };
            ufoSpawner.OnSpawn += (object sender, SpawnArgs args) => 
                                    {
                                        ufo = args.SpawnedObject.GetComponent<SpaceShip>();
                                        ufo.OnDestroy += (object sender, DeathArgs args) => { ufoSpawnTimer = Time.time + spawnTimeAfterKill; };
                                        ufoFireTimer = Time.time + timeBetweenFire;
                                    };
        }

        private void Update()
        {
            if (Time.time > ufoSpawnTimer)
            {
                ufoSpawner.Spawn(new Vector2(-sceneInfo.CameraBoundsExtents.x, UnityEngine.Random.Range(-spawnHeightDelta, spawnHeightDelta)), Quaternion.identity);
                ufoSpawnTimer = Mathf.Infinity;
            }

            if (Time.time > ufoFireTimer)
            {
                ufo.MyGun.Spawn();
                ufoFireTimer = Time.time + timeBetweenFire;
            }

            if (ufo == null)
                return;

            Vector2 target = player == null ? Vector2.up : (Vector2)player.transform.position;

            Vector2 directionToTarget = new Vector2(target.x - ufo.transform.position.x, target.y - ufo.transform.position.y).normalized;
            float angleBetween = Vector2.SignedAngle(ufo.MyGun.transform.localPosition, directionToTarget);

            Move = new Vector2(-Mathf.Sign(angleBetween), 1);
        }

        public void StartTimer()
        {
            ufoSpawnTimer = Time.time + spawnTimeAfterKill;
        }
    }
}