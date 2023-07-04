using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "ScopeStaticData", menuName = "Static Data/Weapon/Scope")]
    public class ScopeStaticData : ScriptableObject
    {
        public float VisionRadius = 1;
        
        public Sprite ScopeSprite;
    }
}