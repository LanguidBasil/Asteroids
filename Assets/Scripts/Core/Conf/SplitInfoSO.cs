using UnityEngine;

using Project.Core.ObjectTypes;

namespace Project.Core.Conf
{
    [CreateAssetMenu(fileName = "New Split Info", menuName = "Project / Core / Split Info")]
    public class SplitInfoSO : ScriptableObject
    {
        public AsteroidType AsteroidToSpawn;
        public Spawner s;
        public int AsteroidsNumber;
        public int AngleBetweenAsteroids;
    }
}
