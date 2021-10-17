using System;
using UnityEngine;

using Project.Tools;

namespace Project.Core.Objects
{
    public class Gun : MonoBehaviour
    {
        [SerializeField]
        private GameObject projectilePrefab;
        [SerializeField]
        private int maxBullets;
        [SerializeField]
        [Tooltip("In seconds")]
        private float reloadTime;

        public Action OnFire;

        private GameObjectPool bullets;
        private float reloadTimer;

        private void Awake()
        {
            bullets = new GameObjectPool(maxBullets, projectilePrefab);

            OnFire += () => { reloadTimer = Time.time + reloadTime; };
        }

        public void Fire()
        {
            if (Time.time > reloadTimer)
            {
                GameObject bullet = bullets.Get();
                if (bullet != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    bullet.SetActive(true);
                    OnFire?.Invoke();
                }
            }
        }
    }
}
