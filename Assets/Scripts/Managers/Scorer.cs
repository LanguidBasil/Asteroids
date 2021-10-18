using System;
using UnityEngine;

namespace Project.Managers
{
    public class Scorer : MonoBehaviour
    {
        [SerializeField]
        private int lifesAtStart;

        public int Score { get; private set; }
        public int Lifes { get; private set; }

        public event EventHandler OnScoreChanged;
        public event EventHandler OnLifeChanged;

        private void Awake()
        {
            Lifes = lifesAtStart;
            OnLifeChanged?.Invoke(this, null);
        }

        public void AddScore(int amount)
        {
            Score += amount;
            OnScoreChanged?.Invoke(this, null);
        }

        public void AddLife(int amount)
        {
            Lifes += amount;
            OnLifeChanged?.Invoke(this, null);
        }
    }
}