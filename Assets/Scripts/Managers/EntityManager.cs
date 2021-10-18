using UnityEngine;

using Project.Core.Objects;
using Project.Core.Spawners;
using Project.Core.Conf;

namespace Project.Managers
{
    public class EntityManager : MonoBehaviour
    {
        [SerializeField]
        private Scorer scorer;
        [Space(8)]
        [SerializeField]
        private SceneInfoSO sceneInfo;
        [SerializeField]
        private Spawner bigAsteroidSpawner;
        [SerializeField]
        private Spawner mediumAsteroidSpawner;
        [SerializeField]
        private Spawner smallAsteroidSpawner;
        [SerializeField]
        private ControllerSpawner playerSpawner;

        private void Awake()
        {
            bigAsteroidSpawner.OnSpawn += (object sender, SpawnArgs args) => { args.SpawnedObject.GetComponent<DestroyableObject>().OnDestroy += DeathMessage; };
            mediumAsteroidSpawner.OnSpawn += (object sender, SpawnArgs args) => { args.SpawnedObject.GetComponent<DestroyableObject>().OnDestroy += DeathMessage; };
            smallAsteroidSpawner.OnSpawn += (object sender, SpawnArgs args) => { args.SpawnedObject.GetComponent<DestroyableObject>().OnDestroy += DeathMessage; };
            playerSpawner.OnSpawn += (object sender, SpawnArgs args) => { args.SpawnedObject.GetComponent<DestroyableObject>().OnDestroy += DeathMessage; };
        }

        private void DeathMessage(object sender, DeathArgs args)
        {
            scorer.AddScore(args.SO.XP);

            DeathSpawnPlayer(sender as SpaceShip, args);
            DeathSpawnAsteroids(sender as Asteroid, args);
        }

        private void DeathSpawnPlayer(SpaceShip player, DeathArgs args)
        {
            if (player == null)
                return;

            scorer.AddLife(-1);
            if (scorer.Lifes > 0)
                playerSpawner.Spawn(Vector3.zero, Quaternion.identity);
        }

        private void DeathSpawnAsteroids(Asteroid asteroid, DeathArgs args)
        {
            if (asteroid == null)
                return;

            float angleStart = args.Sender.transform.eulerAngles.z - asteroid.Split.AngleBetweenAsteroids * (asteroid.Split.AsteroidsNumber - 1) / 2;
            for (int i = 0; i < asteroid.Split.AsteroidsNumber; i++)
            {
                switch (asteroid.Split.AsteroidToSpawn)
                {
                    case AsteroidType.Big:
                        bigAsteroidSpawner.Spawn(args.Sender.transform.position, Quaternion.Euler(0, 0, angleStart + (i * asteroid.Split.AngleBetweenAsteroids)));
                        break;
                    case AsteroidType.Medium:
                        mediumAsteroidSpawner.Spawn(args.Sender.transform.position, Quaternion.Euler(0, 0, angleStart + (i * asteroid.Split.AngleBetweenAsteroids)));
                        break;
                    case AsteroidType.Small:
                        smallAsteroidSpawner.Spawn(args.Sender.transform.position, Quaternion.Euler(0, 0, angleStart + (i * asteroid.Split.AngleBetweenAsteroids)));
                        break;
                    default:
                        break;
                }
            }
        }

        public void GameInit(int bigAsteroidNumber)
        {
            playerSpawner.Spawn(Vector3.zero, Quaternion.identity);

            for (int i = 0; i < bigAsteroidNumber; i++)
            {
                (Vector3, Quaternion) pos = RandomOffCameraPosition();
                bigAsteroidSpawner.Spawn(pos.Item1, pos.Item2);
            }
        }

        private (Vector3, Quaternion) RandomOffCameraPosition()
        {
            Vector2 cameraExtents = sceneInfo.CameraBoundsExtents;
            int angle = Random.Range(-45, 45);
            switch (Random.Range(0, 3))
            {
                // right
                case 0:
                    return (new Vector3(cameraExtents.x, Random.Range(-cameraExtents.y, cameraExtents.y)), Quaternion.Euler(0, 0, angle + 90));
                // up
                case 1:
                    return (new Vector3(Random.Range(-cameraExtents.x, cameraExtents.x), cameraExtents.y), Quaternion.Euler(0, 0, angle + 180));
                // left
                case 2:
                    return (new Vector3(-cameraExtents.x, Random.Range(-cameraExtents.y, cameraExtents.y)), Quaternion.Euler(0, 0, angle + 270));
                // down
                case 3:
                    return (new Vector3(Random.Range(-cameraExtents.x, cameraExtents.x), -cameraExtents.y), Quaternion.Euler(0, 0, angle));
                default:
                    return default;
            }
        }
    }
}
