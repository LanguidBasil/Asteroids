using UnityEngine;

namespace Project.Core.Conf.SO
{
    [CreateAssetMenu(fileName = "New Asteroid", menuName = "Project / Core / Asteroid")]
    public class AsteroidSO : DestroyableObjectSO
    {
        [Header("Asteroid Objects")]
        public AsteroidSplitInfoSO Split;
    }
}