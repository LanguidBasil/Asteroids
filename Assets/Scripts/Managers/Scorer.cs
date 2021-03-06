using System;
using UnityEngine;

namespace Project.Managers
{
    public class Scorer : MonoBehaviour
    {
        public int Score { get; private set; }
        public int Lives { get; private set; }

        public event EventHandler OnScoreChanged;
        public event EventHandler OnLivesChanged;

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

        /// <summary>
        /// Assigns 0 to Score and Lives
        /// </summary>
        public void Clear()
        {
            Score = 0;
            OnScoreChanged?.Invoke(this, null);

            Lives = 0;
            OnLivesChanged?.Invoke(this, null);
        }
    }
}