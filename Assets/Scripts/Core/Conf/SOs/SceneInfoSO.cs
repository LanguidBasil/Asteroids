using UnityEngine;

namespace Project.Core.Conf.SO
{
    [CreateAssetMenu(fileName = "New Scene Info", menuName = "Project / Core / Scene Info")]
    public class SceneInfoSO : ScriptableObject
    {
        [Header("General")]
        public string PlayerName;
        [Header("Input settings")]
        public string KeybordControlSchemeName;
        public string KeybordAndMouseControlSchemeName;
        public string GameplayActionMapName;
        public string UIActionMapName;
        [Header("Camera")]
        public string CameraBoundsGameObjectName;
        [Tooltip("Half the size of the collider")]
        public Vector2 CameraBoundsExtents;
        [Header("Spawners")]
        public string BigAsteroidSpawnerName;
        public string MediumAsteroidSpawnerName;
        public string SmallAsteroidSpawnerName;
        public string PlayerSpawnerName;
        public string UFOSpawnerName;
    }
}
