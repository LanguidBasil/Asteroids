using UnityEngine;

using Project.Core;
using Project.Core.Conf;
using Project.Core.ObjectTypes;

namespace Project.Managers
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField]
        private SceneInfoSO sceneInfo;
        [SerializeField]
        private Spawner bigAsteroidSpawner;
        [SerializeField]
        private Spawner mediumAsteroidSpawner;
        [SerializeField]
        private Spawner smallAsteroidSpawner;
        [Space(8)]
        [SerializeField]
        [Tooltip("Number of big asteroids at start")]
        private int asteroidsAtStart;

        public bool GameActive { get; private set; }

        private void Start()
        {
            GameStart();
        }

        public void GameStart()
        {
            GameActive = true;
            for (int i = 0; i < asteroidsAtStart; i++)
            {
                (Vector3, Quaternion) pos = RandomOffCameraPosition();
                bigAsteroidSpawner.Spawn(pos.Item1, pos.Item2);
            }
        }

        public void GameContinue()
        {

        }

        public void GamePause()
        {

        }

        public void CreateAsteroid(AsteroidType asteroid, Vector3 position, Quaternion rotation)
        {
            switch (asteroid)
            {
                case AsteroidType.Big:
                    bigAsteroidSpawner.Spawn(position, rotation);
                    break;
                case AsteroidType.Medium:
                    mediumAsteroidSpawner.Spawn(position, rotation);
                    break;
                case AsteroidType.Small:
                    smallAsteroidSpawner.Spawn(position, rotation);
                    break;
                default:
                    break;
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
