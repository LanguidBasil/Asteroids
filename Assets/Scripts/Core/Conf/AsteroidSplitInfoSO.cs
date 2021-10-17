using UnityEngine;

using Project.Core.ObjectTypes;

namespace Project.Core.Conf
{
    [CreateAssetMenu(fileName = "New Asteroid Split Info", menuName = "Project / Core / Asteroid Split Info")]
    public class AsteroidSplitInfoSO : ScriptableObject
    {
        public AsteroidType AsteroidToSpawn;
        public int AsteroidsNumber;
        public int AngleBetweenAsteroids;
    }
}
