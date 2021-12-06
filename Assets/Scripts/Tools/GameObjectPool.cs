using UnityEngine;

namespace Project.Tools
{
    public class GameObjectPool
    {
        private readonly GameObject[] pool;

        public GameObjectPool(int maxSize, GameObject prototype)
        {
            pool = new GameObject[maxSize];

            for (int i = 0; i < pool.Length; i++)
                pool[i] = Object.Instantiate(prototype);
        }

        public GameObject Get()
        {
            for (int i = 0; i < pool.Length; i++)
                if (!pool[i].activeInHierarchy)
                    return pool[i];

            return null;
        }

        public void DisableAll()
        {
            for (int i = 0; i < pool.Length; i++)
                pool[i].SetActive(false);
        }
    }
}
