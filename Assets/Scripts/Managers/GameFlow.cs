using UnityEngine;

using Project.Core.ObjectTypes;

namespace Project.Managers
{
    public class GameFlow : MonoBehaviour
    {
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

        }
    }
}
