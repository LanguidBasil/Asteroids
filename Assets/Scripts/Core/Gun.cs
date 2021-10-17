using UnityEngine;

namespace Project.Core
{
    public class Gun : Spawner
    {
        [SerializeField]
        [Tooltip("Green gizmos color")]
        private Transform bulletSpawnPosition;
        [SerializeField]
        [Tooltip("In seconds")]
        private float reloadTime;

        private float reloadTimer;

        protected override void Awake()
        {
            base.Awake();

            OnSpawn += () => { reloadTimer = Time.time + reloadTime; };
        }

        public void Fire()
        {
            if (Time.time > reloadTimer)
                Spawn(bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(bulletSpawnPosition.position, 0.25f);
        }
    }
}
