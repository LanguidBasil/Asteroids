using UnityEngine;

namespace Project.Core.Conf
{
    [CreateAssetMenu(fileName = "New Space Object", menuName = "Project / Core / Space Object")]
    public class SpaceObjectSO : ScriptableObject
    {
        [Header("Space Objects")]
        public SceneInfoSO SceneInfo;
        public float Speed;
        public int DamageOnCollide;
        public ActionOnExitCameraBounds OnExitCameraBounds;
    }
}

