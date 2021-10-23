using UnityEngine;

namespace Project.Core.Conf.SO
{
    [CreateAssetMenu(fileName = "New Asteroid Split Info", menuName = "Project / Core / Asteroid Split Info")]
    public class AsteroidSplitInfoSO : ScriptableObject
    {
        public AsteroidType AsteroidToSpawn;
        public int AsteroidsNumber;
        public int AngleBetweenAsteroids;
    }
}
