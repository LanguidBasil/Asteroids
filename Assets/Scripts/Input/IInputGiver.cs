namespace Project.Input
{
    public interface IInputGiver
    {
        public float Rotation { get; }
        public bool Acceleration { get; }
        public bool Fire { get; }
    }
}
