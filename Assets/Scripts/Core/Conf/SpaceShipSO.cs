using UnityEngine;

namespace Project.Core.Conf
{
    [CreateAssetMenu(fileName = "New Space Ship", menuName = "Project / Core / Space Ship")]
    public class SpaceShipSO : DestroyableObjectSO
    {
        [Header("SpaceShip Objects")]
        public float MaxSpeed;
        [Tooltip("In degrees per frame")]
        public int RotationSpeed;
    }
}