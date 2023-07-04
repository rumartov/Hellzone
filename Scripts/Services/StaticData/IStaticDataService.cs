using StaticData;

namespace Services.StaticData
{
    public interface IStaticDataService
    {
        void Load();
        UnitStaticData ForUnit(UnitTypeId unitTypeId);
        WeaponStaticData ForWeapon();
        ProjectileStaticData ForProjectile();
    }
}