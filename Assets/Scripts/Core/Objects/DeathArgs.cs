using System;

using Project.Core.Conf;

namespace Project.Core.Objects
{
    public class DeathArgs : EventArgs
    {
        public SpaceObjectSO SO;

        public DeathArgs(SpaceObjectSO so)
        {
            SO = so;
        }
    }
}
