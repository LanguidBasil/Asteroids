using System;
using UnityEngine;

using Project.Core.Conf;

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

            if (OnHealthDecrease != null)
                foreach (var d in OnHealthDecrease.GetInvocationList())
                    OnHealthDecrease -= (EventHandler)d;

            if (OnDestroy != null)
                foreach (var d in OnDestroy.GetInvocationList())
                    OnDestroy -= (EventHandler<DeathArgs>)d;

            invincibilityTimer = Time.time + ((DestroyableObjectSO)SO).InvincibiltyTime;
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
