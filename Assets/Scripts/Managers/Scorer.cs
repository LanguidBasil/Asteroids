using UnityEngine;

namespace Project.Managers
{
    public class Scorer : MonoBehaviour
    {
        [SerializeField]
        private int lifesAtStart;

        public int Score { get; private set; }
        public int Lifes { get; private set; }

        private void Awake()
        {
            Lifes = lifesAtStart;
        }

        public void AddScore(int amount)
        {
            Score += amount;
        }

        public void AddLife(int amount)
        {
            Lifes += amount;
        }
    }
}