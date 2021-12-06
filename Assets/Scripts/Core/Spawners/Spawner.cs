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
        [SerializeField]
        private AudioSource audioOnSpawn;

        public virtual event EventHandler<SpawnArgs> OnSpawn;

        protected GameObjectPool pool;
        protected IMovementInput input;

        protected virtual void Awake()
        {
            pool = new GameObjectPool(maxCount, prefab);
        }

        /// <returns>
        /// returns true if spawn succeded and false otherwise
        /// </returns>
        public virtual bool Spawn(Vector3 position, Quaternion rotation)
        {
            var gameObj = pool.Get();
            if (gameObj != null)
            {
                if (input != null)
                    gameObj.GetComponent<SpaceShip>()?.SetInput(input);

                gameObj.transform.SetPositionAndRotation(position, rotation);
                gameObj.SetActive(true);
                OnSpawn?.Invoke(this, new SpawnArgs(gameObj, position, rotation));

                if (audioOnSpawn != null)
                    audioOnSpawn.Play();

                return true;
            }

            Debug.LogWarning($"Pool on {gameObject.name} was empty and spawn failed");
            return false;
        }

        public virtual void KillAll()
        {
            pool.DisableAll();
        }

        public void SetInputs(IMovementInput input)
        {
            this.input = input;
        }
    }
}
