using UnityEngine;

using Project.Core.ObjectTypes;

namespace Project.Core.Conf
{
    [CreateAssetMenu(fileName = "New Space Object", menuName = "Project / Core / Split")]
    public class SplitSO : ScriptableObject
    {
        public AsteroidType AsteroidToSpawn;
        public int AsteroidsNumber;
        public int AngleBetweenAsteroids;
    }
}
