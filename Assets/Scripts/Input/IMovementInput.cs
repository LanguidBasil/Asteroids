using UnityEngine;

namespace Project.Input
{
    public interface IMovementInput
    {
        public Vector2 LookPosition { get; }
        public Vector2 Navigation { get; }
        public bool Fire { get; }
    }
}
