using System;
using UnityEngine;

using Project.Core.Objects;
using Project.Input;

namespace Project.Core.Spawners
{
    public class ControllerSpawner : Spawner
    {
        [SerializeField]
        private GameObject input;

        public override event EventHandler<SpawnArgs> OnSpawn;

        public override bool Spawn(Vector3 position, Quaternion rotation)
        {
            GameObject gameObj = pool.Get();
            if (gameObj != null)
            {
                gameObj.transform.SetPositionAndRotation(position, rotation);
                gameObj.GetComponent<SpaceShip>().SetInput(input.GetComponent<IMovementInput>());
                gameObj.SetActive(true);
                OnSpawn?.Invoke(this, new SpawnArgs(gameObj, position, rotation));
                return true;
            }

            Debug.LogWarning($"Pool on {gameObject.name} was empty and spawn failed");
            return false;
        }
    }
}