using UnityEngine;

namespace Project.Core
{
    [CreateAssetMenu(fileName = "New Space Object SO", menuName = "Project / Core / Space Object SO")]
    public class SpaceObjectSO : ScriptableObject
    {
        [Header("Space Objects")]
        public int Speed;
        public int Damage;

        [Header("Destroyable Objects")]
        public int StartingHealth;
        public int XP;

        [Header("SpaceShip Objects")]
        public int MaxSpeed;
        [Tooltip("In degrees per frame")]
        public int RotationSpeed;
    }
}

