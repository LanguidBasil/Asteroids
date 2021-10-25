using UnityEngine;

namespace Project.Managers
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField]
        private Scorer scorer;
        [SerializeField]
        private EntityManager deathGatherer;
        [SerializeField]
        private UFOManager ufoManager;
        [Space(8)]
        [SerializeField]
        private int livesOnStart;
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
            scorer.Clear();
            scorer.AddLife(livesOnStart);
            ufoManager.StartTimer();
            Time.timeScale = 1;

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
    }
}
