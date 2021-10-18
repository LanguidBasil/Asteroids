using UnityEngine;

namespace Project.Input
{
    public interface IInputGiver
    {
        public Vector2 MousePosition { get; }
        public float Rotation { get; }
        public bool Acceleration { get; }
        public bool Fire { get; }
    }
}
