using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "BodyStaticData", menuName = "Static Data/Weapon/Body")]
    public class BodyStaticData : ScriptableObject
    {
        public ProjectileTypeId ProjectileTypeId;
        
        public Sprite BodySprite;
    }
}