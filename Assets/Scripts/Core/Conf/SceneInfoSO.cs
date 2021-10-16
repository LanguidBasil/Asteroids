using UnityEngine;

namespace Project.Core.Conf
{
    [CreateAssetMenu(fileName = "New Scene Info SO", menuName = "Project / Core / Scene Info SO")]
    public class SceneInfoSO : ScriptableObject
    {
        public string CameraBoundsGameObjectName;
    }
}
