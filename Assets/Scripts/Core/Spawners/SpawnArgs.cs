using System;
using UnityEngine;

namespace Project.Core.Spawners
{
    public class SpawnArgs : EventArgs
    {
        public GameObject SpawnedObject;
        public Vector3 Position;
        public Quaternion Rotation;

        public SpawnArgs(GameObject spawnedObject, Vector3 position, Quaternion rotation)
        {
            SpawnedObject = spawnedObject;
            Position = position;
            Rotation = rotation;
        }
    }
}
