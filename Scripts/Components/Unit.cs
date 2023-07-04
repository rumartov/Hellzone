using UnityComponents;
using UnityEngine;

namespace Components
{
    public struct Unit
    {
        public GameObject Object;

        public Transform Transform;
        public Transform Aim;
        public Transform Visual;

        public Weapon Weapon;

        public float MovementSpeed;
    }
}