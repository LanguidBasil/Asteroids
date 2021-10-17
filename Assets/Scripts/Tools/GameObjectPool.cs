using UnityEngine;

namespace Project.Tools
{
    public class GameObjectPool
    {
        private readonly int maxSize;
        private readonly GameObject[] pool;

        public GameObjectPool(int maxSize, GameObject prototype)
        {
            this.maxSize = maxSize;
            this.pool = new GameObject[maxSize];

            for (int i = 0; i < maxSize; i++)
            {
                pool[i] = Object.Instantiate(prototype);
                pool[i].SetActive(false);
            }
        }

        public GameObject Get()
        {
            for (int i = 0; i < maxSize; i++)
                if (!pool[i].activeInHierarchy)
                    return pool[i];

            return null;
        }
    }
}
