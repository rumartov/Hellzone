using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "WeaponStaticData", menuName = "Static Data/Weapon")]
    public class WeaponStaticData : ScriptableObject
    {
        public GameObject WeaponPrefab;
    }
}