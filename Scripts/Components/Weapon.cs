using StaticData;
using UnityComponents;
using UnityEngine;

namespace Components
{
    public struct Weapon
    {
        public int EntityId;
        public GameObject Object;
        
        public WeaponView View;

        public Transform ShootPoint;
        public Transform Transform;
        public GameObject Owner;

        public Barrel Barrel;
        public Body Body;
        public Scope Scope;
        public Stock Stock;
    }

    public struct Barrel
    {
        public Transform ShootPoint;
        
        public float ProjectileSizeModifyer;
        public float ProjectileAmountModifyer;
        public float ProjectileSpeedModifyer;
        public float ProjectileShootAngleModyfier;
        public float ProjectileRangeModifyer;
    }
    
    public struct Body
    {
        public ProjectileTypeId ProjectileTypeId;
    }
    
    public struct Scope
    {
        public float VisionRadiusModifyer;
    }
    
    public struct Stock
    {
        public float RecoilModifyer;
        public float ReloadSpeedModifyer;
    }
}