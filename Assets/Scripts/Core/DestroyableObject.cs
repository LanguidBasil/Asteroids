using System;

namespace Project.Core
{
    public class DestroyableObject : SpaceObject
    {
        public int Health { get; protected set; }

        public Action OnHealthDecrease;
        public Action OnDestroy;

        public void DecreaseHealth(int amount)
        {
            Health -= amount;
            OnHealthDecrease?.Invoke();

            if (Health < 1)
            {
                OnDestroy?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}
