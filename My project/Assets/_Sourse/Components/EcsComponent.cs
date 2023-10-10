using System;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct EcsComponent {
        public float Conunter;
        public Transform Anchor;
    }
}