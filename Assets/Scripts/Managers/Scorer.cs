using UnityEngine;

namespace Project.Managers
{
    public class Scorer : MonoBehaviour
    {
        public int Score { get; private set; }
        public int Lifes { get; private set; }

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