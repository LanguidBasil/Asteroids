using UnityEngine;

namespace Project.Input
{
    public interface IMovementInput
    {
        public Vector2 LookPosition { get; }
        public float Rotation { get; }
        public bool Acceleration { get; }
        public bool Fire { get; }
    }
}
