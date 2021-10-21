using System;
using UnityEngine;

namespace Project.Managers
{
    public class Scorer : MonoBehaviour
    {
        [SerializeField]
        private int livesAtStart;

        public int Score { get; private set; }
        public int Lives { get; private set; }

        public event EventHandler OnScoreChanged;
        public event EventHandler OnLivesChanged;

        private void Awake()
        {
            Lives = livesAtStart;
            OnLivesChanged?.Invoke(this, null);
        }

        public void AddScore(int amount)
        {
            Score += amount;
            OnScoreChanged?.Invoke(this, null);
        }

        public void AddLife(int amount)
        {
            Lives += amount;
            OnLivesChanged?.Invoke(this, null);
        }
    }
}