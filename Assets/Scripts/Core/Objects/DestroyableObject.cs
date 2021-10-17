using System;
using UnityEngine;

namespace Project.Core.Objects
{
    public class DestroyableObject : SpaceObject
    {
        public int Health { get; protected set; }

        public event EventHandler OnHealthDecrease;
        public event EventHandler<DeathArgs> OnDestroy;

        private float invincibilityTimer;

        protected override void OnEnable()
        {
            base.OnEnable();

            invincibilityTimer = Time.time + SO.InvincibiltyTime;
        }

        public void DecreaseHealth(int amount)
        {
            if (Time.time < invincibilityTimer)
                return;

            Health -= amount;
            OnHealthDecrease?.Invoke(this, null);

            if (Health < 1)
            {
                OnDestroy?.Invoke(this, new DeathArgs(SO, gameObject));
                gameObject.SetActive(false);
            }
        }
    }
}
