using System;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct MovmentEcsComponent
    {
        public float Speed;
        public float Amlitude;
        public Transform transform;
        public float startZ;
    }
}