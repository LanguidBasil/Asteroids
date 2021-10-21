using System;
using System.Linq;
using UnityEngine;

namespace Project.Core.Objects
{
    public class DestroyableObject : SpaceObject
    {
        public int Health { get; protected set; }

        private event EventHandler<DeathArgs> onDestroy;

        public event EventHandler OnHealthDecrease;
        public event EventHandler<DeathArgs> OnDestroy
        {
            add
            {
                if (onDestroy == null || !onDestroy.GetInvocationList().Contains(value))
                    onDestroy += value;
            }
            remove
            {
                onDestroy -= value;
            }
        }

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
                onDestroy?.Invoke(this, new DeathArgs(SO, gameObject));
                gameObject.SetActive(false);
            }
        }
    }
}
