using UnityEngine;

namespace Project.Core.Spawners
{
    public class Gun : ReloadSpawner
    {
        [SerializeField]
        [Tooltip("Green gizmos color")]
        private Transform bulletSpawn;

        public bool Spawn()
        {
            return base.Spawn(bulletSpawn.position, bulletSpawn.rotation);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(bulletSpawn.position, 0.25f);
        }
    }
}
