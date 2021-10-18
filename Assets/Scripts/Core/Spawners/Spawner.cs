using System;
using UnityEngine;

using Project.Tools;

namespace Project.Core.Spawners
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        protected GameObject prefab;
        [SerializeField]
        [Tooltip("Max number of simultaneously active objects in scene. \nFor performance keep as low as possible")]
        protected int maxCount;

        public event EventHandler<SpawnArgs> OnSpawn;

        protected GameObjectPool pool;

        protected virtual void Awake()
        {
            pool = new GameObjectPool(maxCount, prefab);
        }

        /// <returns>
        /// returns true if spawn succeded and false otherwise
        /// </returns>
        public virtual bool Spawn(Vector3 position, Quaternion rotation)
        {
            GameObject gameObj = pool.Get();
            if (gameObj != null)
            {
                gameObj.transform.SetPositionAndRotation(position, rotation);
                gameObj.SetActive(true);
                OnSpawn?.Invoke(this, new SpawnArgs(gameObj, position, rotation));
                return true;
            }

            Debug.LogWarning($"Pool on {gameObject.name} was empty and spawn failed");
            return false;
        }

        /// <summary>
        /// Disables all spawned objects
        /// </summary>
        public virtual void KillAll()
        {
            pool.DisableAll();
        }
    }
}
