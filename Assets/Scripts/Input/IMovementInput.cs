using System;
using UnityEngine;

namespace Project.Input
{
    public interface IMovementInput
    {
        public Vector2 Move { get; }
        public Action Fire { get; set; }
    }
}
