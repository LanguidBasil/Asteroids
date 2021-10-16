using System;

namespace Project.Core
{
    public class DestroyableObject : SpaceObject
    {
        public int Health { get; protected set; }

        public Action OnHealthDecrease;
        public Action OnDestroy;
    }
}
