using UnityEngine;

namespace Project.Core.Spawners
{
    public class ReloadSpawner : Spawner
    {
        [SerializeField]
        [Tooltip("In seconds")]
        private float reloadTime;

        private float reloadTimer;

        protected override void Awake()
        {
            base.Awake();

            OnSpawn += (object sender, SpawnArgs args) => { reloadTimer = Time.time + reloadTime; };
        }

        public override bool Spawn(Vector3 position, Quaternion rotation)
        {
            return Time.time > reloadTimer ? base.Spawn(position, rotation) : false;
        }
    }
}
