using UnityEngine;

namespace Project.Core.Conf
{
    [CreateAssetMenu(fileName = "New Destroyable Object", menuName = "Project / Core / Destroyable Object")]
    public class DestroyableObjectSO : SpaceObjectSO
    {
        [Header("Destroyable Objects")]
        [Tooltip("In seconds")]
        public float InvincibiltyTime;
        public int StartingHealth;
        public int XP;
    }
}