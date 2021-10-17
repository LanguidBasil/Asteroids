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
        private Spawner BigAsteroidSpawner;
        [SerializeField]
        private Spawner MediumAsteroidSpawner;
        [SerializeField]
        private Spawner SmallAsteroidSpawner;
        [Space(8)]
        [SerializeField]
        [Tooltip("Number of big asteroids at start")]
        private int asteroidsAtStart;

        public bool GameActive { get; private set; }

        public void GameStart()
        {

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
                    BigAsteroidSpawner.Spawn(position, rotation);
                    break;
                case AsteroidType.Medium:
                    MediumAsteroidSpawner.Spawn(position, rotation);
                    break;
                case AsteroidType.Small:
                    SmallAsteroidSpawner.Spawn(position, rotation);
                    break;
                default:
                    break;
            }
        }

        private Vector3 RandomOffCameraPosition()
        {
            return default;
        }
    }
}
