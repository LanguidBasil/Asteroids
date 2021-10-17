using System;

namespace Project.Core.Objects
{
    public class DestroyableObject : SpaceObject
    {
        public int Health { get; protected set; }

        public event EventHandler OnHealthDecrease;
        public event EventHandler<DeathArgs> OnDestroy;

        public void DecreaseHealth(int amount)
        {
            Health -= amount;
            OnHealthDecrease?.Invoke(this, null);

            if (Health < 1)
            {
                OnDestroy?.Invoke(this, new DeathArgs(SO));
                gameObject.SetActive(false);
            }
        }
    }
}
