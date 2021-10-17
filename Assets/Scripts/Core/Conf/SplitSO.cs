using UnityEngine;

using Project.Core.ObjectTypes;

namespace Project.Core.Conf
{
    public class SplitSO : ScriptableObject
    {
        public AsteroidType AsteroidToSpawn;
        public int AsteroidsNumber;
        public int AngleBetweenAsteroids;
    }
}
