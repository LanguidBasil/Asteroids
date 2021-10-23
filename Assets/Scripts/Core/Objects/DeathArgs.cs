using System;
using UnityEngine;

using Project.Core.Conf.SO;

namespace Project.Core.Objects
{
    public class DeathArgs : EventArgs
    {
        public GameObject Sender;
        public SpaceObjectSO SO;

        public DeathArgs(SpaceObjectSO so, GameObject sender)
        {
            SO = so;
            Sender = sender;
        }
    }
}
