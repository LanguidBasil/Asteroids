using UnityEngine;

using Project.Core.ObjectTypes;

namespace Project.Core.Conf
{
    [CreateAssetMenu(fileName = "New Split Info", menuName = "Project / Core / Split Info")]
    public class SplitInfoSO : ScriptableObject
    {
        public AsteroidType AsteroidToSpawn;
        public int AsteroidsNumber;
        public int AngleBetweenAsteroids;
    }
}
