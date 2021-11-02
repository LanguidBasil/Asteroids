using UnityEngine;

namespace Project.Core.Conf.SO
{
    [CreateAssetMenu(fileName = "New Scene Info", menuName = "Project / Core / Scene Info")]
    public class SceneInfoSO : ScriptableObject
    {
        [Header("Camera")]
        public string CameraBoundsGameObjectName;
        [Tooltip("Half the size of the collider")]
        public Vector2 CameraBoundsExtents;
        [Header("Spawners")]
        public string bigAsteroidSpawnerName;
        public string mediumAsteroidSpawnerName;
        public string smallAsteroidSpawnername;
        public string playerSpawnerName;
        public string ufoSpawnerName;
    }
}
