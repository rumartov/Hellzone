using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "BarrelStaticData", menuName = "Static Data/Weapon/Barrel")]
    public class BarrelStaticData : ScriptableObject
    {
        public float ProjectileSize = 1;
        public float ProjectileAmount = 1;
        public float ProjectileSpeed = 1;

        public Sprite BarrelSprite;
    }
}