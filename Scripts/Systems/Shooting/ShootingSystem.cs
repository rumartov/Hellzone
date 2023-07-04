using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factory;
using UnityEngine;

internal sealed class ShootingSystem : IEcsRunSystem
{
    private readonly EcsWorldInject _world = default;
    private readonly EcsFilterInject<Inc<Weapon, Shooting>> _filterWeapon = default;
    private readonly EcsPoolInject<Weapon> _poolWeapon = default;
    private readonly EcsCustomInject<IGameFactory> _factory = default;

    public void Run(IEcsSystems systems)
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var index in _filterWeapon.Value)
            {
                ref Weapon weapon = ref _poolWeapon.Value.Get(index);
            
                float projectileSpeedModifyer = weapon.Barrel.ProjectileSpeedModifyer;
                float projectileSizeModifyer = weapon.Barrel.ProjectileSizeModifyer;
                float projectileAmountModifyer = weapon.Barrel.ProjectileAmountModifyer;
                float projectileShootAngleModyfier = weapon.Barrel.ProjectileShootAngleModyfier;
                float projectileRangeModifyer = weapon.Barrel.ProjectileRangeModifyer;

                Transform barrelShootPoint = weapon.Barrel.ShootPoint;
                
                ShootProjectile(barrelShootPoint.position, -barrelShootPoint.right, 
                    projectileSpeedModifyer, 10);
            }
        }
    }

    private void ShootProjectile(Vector3 startPoint, Vector3 direction, float speedModifyer, float range)
    {
        _factory.Value.CreateBullet(startPoint, direction, speedModifyer, range);
    }
    
    private void ShootRay(Vector3 startPoint, Vector3 direction, float speed, float range)
    {
        
    }
}

internal struct Bullet
{
    public GameObject Object;
    public Vector3 Direction;
    public float Speed;
}