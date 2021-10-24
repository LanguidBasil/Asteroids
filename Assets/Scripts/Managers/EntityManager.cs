using UnityEngine;

using Project.Core.Objects;
using Project.Core.Spawners;
using Project.Core.Conf;
using Project.Core.Conf.SO;

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
        private Spawner playerSpawner;
        [SerializeField]
        private Spawner ufoSpawner;

        private Spawner[] spawners;
        private int aliveSpaceObjects;
        private int asteroidsOnLastRoundStart;

        private void Awake()
        {
            spawners = new[] { bigAsteroidSpawner, mediumAsteroidSpawner, smallAsteroidSpawner, playerSpawner };

            void f(object sender, SpawnArgs args)
            {
                aliveSpaceObjects++;
                args.SpawnedObject.GetComponent<DestroyableObject>().OnDestroy += DeathMessage;
            }

            foreach (var spawner in spawners)
                spawner.OnSpawn += f;
        }

        private void DeathMessage(object sender, DeathArgs args)
        {
            aliveSpaceObjects--;

            var so = args.SO as DestroyableObjectSO;
            if (so != null)
                scorer.AddScore(so.XP);

            if (args.Sender.name == playerName)
                DeathSpawnPlayer(args.Sender.GetComponent<SpaceShip>(), args);
            DeathSpawnAsteroids(args.Sender.GetComponent<DestroyableObject>(), args);

            if (aliveSpaceObjects == 1)
            {
                asteroidsOnLastRoundStart++;
                SpawnAsteroidOffCamera(AsteroidType.Big, asteroidsOnLastRoundStart);
            }
        }

        private void DeathSpawnPlayer(SpaceShip player, DeathArgs args)
        {
            scorer.AddLife(-1);
            if (scorer.Lives > 0)
                playerSpawner.Spawn(Vector3.zero, Quaternion.identity);
        }

        private void DeathSpawnAsteroids(DestroyableObject asteroid, DeathArgs args)
        {
            if (asteroid == null || asteroid.SO as AsteroidSO == null)
                return;
            AsteroidSplitInfoSO split = ((AsteroidSO)asteroid.SO).Split;

            float angleStart = args.Sender.transform.eulerAngles.z - split.AngleBetweenAsteroids * (split.AsteroidsNumber - 1) / 2;
            Spawner spawner = null;
            switch (split.AsteroidToSpawn)
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

            for (int i = 0; i < split.AsteroidsNumber; i++)
                spawner?.Spawn(args.Sender.transform.position, Quaternion.Euler(0, 0, angleStart + (i * split.AngleBetweenAsteroids)));
        }

        public void GameInit(int bigAsteroidNumber)
        {
            asteroidsOnLastRoundStart = bigAsteroidNumber;

            foreach (var spawner in spawners)
                spawner.KillAll();

            playerSpawner.Spawn(Vector3.zero, Quaternion.identity);
            SpawnAsteroidOffCamera(AsteroidType.Big, asteroidsOnLastRoundStart);
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
