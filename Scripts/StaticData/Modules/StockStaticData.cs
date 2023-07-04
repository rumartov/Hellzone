using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "StockStaticData", menuName = "Static Data/Weapon/Stock")]
    public class StockStaticData : ScriptableObject
    {
        public float Recoil = 1;
        public float ReloadSpeed = 1;
        
        public Sprite StockSprite;
    }
}