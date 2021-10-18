using UnityEngine;

namespace Project.Managers
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField]
        private EntityManager deathGatherer;
        [Space(8)]
        [SerializeField]
        [Tooltip("Number of big asteroids at start")]
        private int asteroidsAtStart;

        public bool GameActive { get; private set; }

        private void Awake()
        {
            GameActive = false;
        }

        public void GameStart()
        {
            deathGatherer.GameInit(asteroidsAtStart);
            GameActive = true;
        }

        public void GameContinue()
        {
            GameActive = true;
            Time.timeScale = 1;
        }

        public void GamePause()
        {
            GameActive = false;
            Time.timeScale = 0;
        }

        public void GameQuit()
        {
            Application.Quit();
        }
    }
}
