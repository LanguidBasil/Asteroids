using UnityEngine;

namespace Project.Core.Conf
{
    [CreateAssetMenu(fileName = "New Space Object SO", menuName = "Project / Core / Space Object SO")]
    public class SpaceObjectSO : ScriptableObject
    {
        [Header("Space Objects")]
        public SceneInfoSO SceneInfo;
        public int Speed;
        public int Damage;
        public OnExitCameraBounds eOnExitCameraBounds;

        [Header("Destroyable Objects")]
        public int StartingHealth;
        public int XP;
        //public eActionOnDeath ActionOnDeath;
        //public SplitContext SplitContext;

        [Header("SpaceShip Objects")]
        public int MaxSpeed;
        [Tooltip("In degrees per frame")]
        public int RotationSpeed;
    }
}

