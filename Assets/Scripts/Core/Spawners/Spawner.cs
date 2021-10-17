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

        public Action OnSpawn;

        protected GameObjectPool pool;

        protected virtual void Awake()
        {
            pool = new GameObjectPool(maxCount, prefab);
        }

        /// <returns>
        /// returns true if spawn succeded and false otherwise
        /// </returns>
        public bool Spawn(Vector3 position, Quaternion rotation)
        {
            GameObject gameObj = pool.Get();
            if (gameObj != null)
            {
                gameObj.transform.SetPositionAndRotation(position, rotation);
                gameObj.SetActive(true);
                OnSpawn?.Invoke();
                return true;
            }

            Debug.LogWarning($"Pool on {gameObject.name} was empty and spawn failed");
            return false;
        }

        /// <returns>
        /// returns true if spawn succeded and false otherwise
        /// </returns>
        public bool Spawn(Vector3 position, Vector3 rotationInEulerAngles)
        {
            return Spawn(position, Quaternion.Euler(rotationInEulerAngles));
        }
    }
}
