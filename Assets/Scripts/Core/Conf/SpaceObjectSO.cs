using UnityEngine;

namespace Project.Core.Conf
{
    [CreateAssetMenu(fileName = "New Space Object", menuName = "Project / Core / Space Object")]
    public class SpaceObjectSO : ScriptableObject
    {
        [Header("Space Objects")]
        public SceneInfoSO SceneInfo;
        public int Speed;
        public int DamageOnCollide;
        public ActionOnExitCameraBounds eOnExitCameraBounds;

        [Header("Destroyable Objects")]
        public int StartingHealth;
        public int XP;
        public ActionOnDeath OnDeath;
        public SplitSO Split;

        [Header("SpaceShip Objects")]
        public int MaxSpeed;
        [Tooltip("In degrees per frame")]
        public int RotationSpeed;
    }
}

