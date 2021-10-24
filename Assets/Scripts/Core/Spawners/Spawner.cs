using System;
using UnityEngine;

using Project.Core.Objects;
using Project.Input;
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

        public virtual event EventHandler<SpawnArgs> OnSpawn;

        protected GameObjectPool pool;
        protected IMovementInput input;

        protected virtual void Awake()
        {
            pool = new GameObjectPool(maxCount, prefab);
            input = null;
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
                if (input != null)
                    gameObj.GetComponent<SpaceShip>()?.SetInput(input);

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

        public void SetInputs(IMovementInput input)
        {
            Debug.Log($"Setting input on {gameObject.name}");
            this.input = input;
        }
    }
}
