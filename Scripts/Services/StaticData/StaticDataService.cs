using System.Collections.Generic;
using System.Linq;
using StaticData;
using UnityEngine;

namespace Services.StaticData
{
    internal class StaticDataService : IStaticDataService
    {
        private const string UnitDataPath = "Static Data/Units/";
        private const string WeaponDataPath = "Static Data/Weapon/Weapon";

        private Dictionary<UnitTypeId, UnitStaticData> _unitStaticDatas;
        private WeaponStaticData _weaponStaticData;

        public void Load()
        {
            _unitStaticDatas = Resources
                .LoadAll<UnitStaticData>(UnitDataPath)
                .ToDictionary(x => x.UnitTypeId, x => x);

            _weaponStaticData = Resources.Load<WeaponStaticData>(WeaponDataPath);
        }

        public UnitStaticData ForUnit(UnitTypeId unitTypeId)
        {
            return _unitStaticDatas.TryGetValue(unitTypeId, out var staticData)
                ? staticData
                : null;
        }

        public WeaponStaticData ForWeapon()
        {
            return _weaponStaticData;
        }

        public ProjectileStaticData ForProjectile()
        {
            throw new System.NotImplementedException();
        }
    }
}