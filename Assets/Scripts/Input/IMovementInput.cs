using UnityEngine;

namespace Project.Input
{
    public interface IMovementInput
    {
        public Vector2 Look { get; }
        public Vector2 Move { get; }
        public bool Fire { get; }
    }
}
