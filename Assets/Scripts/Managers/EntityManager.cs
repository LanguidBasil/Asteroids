using UnityEngine;

using Project.Core.Objects;
using Project.Core.Spawners;
using Project.Core.Conf;

namespace Project.Managers
{
    public class EntityManager : MonoBehaviour
    {
        [SerializeField]
        private string playerName;
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

        private Spawner[] spawners;

        private void Awake()
        {
            spawners = new[] { bigAsteroidSpawner, mediumAsteroidSpawner, smallAsteroidSpawner, playerSpawner };

            void f(object sender, SpawnArgs args)
            {
                args.SpawnedObject.GetComponent<DestroyableObject>().OnDestroy += DeathMessage;
            }

            foreach (var spawner in spawners)
                spawner.OnSpawn += f;
        }

        private void DeathMessage(object sender, DeathArgs args)
        {
            scorer.AddScore(args.SO.XP);

            if (args.Sender.name == playerName)
                DeathSpawnPlayer(args.Sender.GetComponent<SpaceShip>(), args);
            DeathSpawnAsteroids(args.Sender.GetComponent<Asteroid>(), args);
        }

        private void DeathSpawnPlayer(SpaceShip player, DeathArgs args)
        {
            scorer.AddLife(-1);
            if (scorer.Lives > 0)
                playerSpawner.Spawn(Vector3.zero, Quaternion.identity);
        }

        private void DeathSpawnAsteroids(Asteroid asteroid, DeathArgs args)
        {
            if (asteroid == null)
                return;

            float angleStart = args.Sender.transform.eulerAngles.z - asteroid.Split.AngleBetweenAsteroids * (asteroid.Split.AsteroidsNumber - 1) / 2;
            Spawner spawner = null;
            switch (asteroid.Split.AsteroidToSpawn)
            {
                case AsteroidType.Big:
                    spawner = bigAsteroidSpawner;
                    break;
                case AsteroidType.Medium:
                    spawner = mediumAsteroidSpawner;
                    break;
                case AsteroidType.Small:
                    spawner = smallAsteroidSpawner;
                    break;
                default:
                    Debug.LogError("Unknown asteroid type");
                    break;
            }

            for (int i = 0; i < asteroid.Split.AsteroidsNumber; i++)
                spawner?.Spawn(args.Sender.transform.position, Quaternion.Euler(0, 0, angleStart + (i * asteroid.Split.AngleBetweenAsteroids)));
        }

        public void GameInit(int bigAsteroidNumber)
        {
            foreach (var spawner in spawners)
                spawner.KillAll();

            playerSpawner.Spawn(Vector3.zero, Quaternion.identity);
            SpawnAsteroidOffCamera(AsteroidType.Big, bigAsteroidNumber);
        }

        private void SpawnAsteroidOffCamera(AsteroidType asteroid, int number)
        {
            Spawner spawner = null;
            switch (asteroid)
            {
                case AsteroidType.Big:
                    spawner = bigAsteroidSpawner;
                    break;
                case AsteroidType.Medium:
                    spawner = mediumAsteroidSpawner;
                    break;
                case AsteroidType.Small:
                    spawner = smallAsteroidSpawner;
                    break;
                default:
                    Debug.LogError("Unknown asteroid type");
                    break;
            }

            for (int i = 0; i < number; i++)
            {
                (Vector3, Quaternion) pos = RandomOffCameraPosition();
                spawner?.Spawn(pos.Item1, pos.Item2);
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
