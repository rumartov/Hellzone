using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "UnitStaticData", menuName = "Static Data/Unit")]
    public class UnitStaticData : ScriptableObject
    {
        public UnitTypeId UnitTypeId;

        public float MovementSpeed = 10f;
        public GameObject Prefab;
    }

    public enum UnitTypeId
    {
        Hero,
        Skull,
        Robot
    }
}