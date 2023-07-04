using Components;
using Leopotam.EcsLite;
using Services.StaticData;
using StaticData;
using UnityComponents;
using UnityEngine;

namespace Services.Factory
{
    internal class GameFactory : IGameFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly EcsWorld _world;

        public GameFactory(EcsWorld world, IStaticDataService staticDataService)
        {
            _world = world;
            _staticDataService = staticDataService;
        }

        public GameObject Hero { get; set; }

        public void CreateHero()
        {
            var entity = _world.NewEntity();

            ref var hero = ref _world
                .GetPool<Unit>()
                .Add(entity);

            var unitStaticData = _staticDataService.ForUnit(UnitTypeId.Hero);

            var heroObject = CreateUnit(unitStaticData, ref hero);

            Hero = heroObject;

            _world.GetPool<Hero>().Add(entity);
        }

        public void CreateBullet(Vector3 startPoint, Vector3 direction, float speedModifyer, float range)
        {
            var entity = _world.NewEntity();

            ref Bullet bullet = ref _world
                .GetPool<Bullet>()
                .Add(entity);

            //_staticDataService.ForProjectile();
            // Static data
            float projectileBaseSpeed = 10;
            
            
            GameObject bulletPrefab = (GameObject) Resources.Load("Weapons/Projectiles/Bullet");
            GameObject bulletObject = Instantiate(bulletPrefab, startPoint);

            bullet.Object = bulletObject;
            bullet.Direction = direction;
            bullet.Speed = CalculateProjectileSpeed(projectileBaseSpeed, speedModifyer);
        }

        private static float CalculateProjectileSpeed(float baseSpeed, float speedModifyer)
        {
            return baseSpeed * speedModifyer;
        }

        public Weapon CreateWeapon(GameObject unit)
        {
            int entity = _world.NewEntity();
            ref Weapon weapon = ref _world
                .GetPool<Weapon>()
                .Add(entity);

            WeaponStaticData weaponStaticData = _staticDataService.ForWeapon();

            // TODO Set correct static data
            float projectileAmountData = 1;
            float projectileSizeData = 1;
            float projectileSpeedData = 1;
            
            ProjectileTypeId projectileTypeIdData = ProjectileTypeId.Bullet;
            
            float visionRadiusData = 1;
            
            float recoilData = 1;
            float reloadSpeedData = 1;


            Transform offset = unit.GetComponent<UnitView>().offset;

            GameObject weaponObject = Instantiate(weaponStaticData.WeaponPrefab, offset);

            WeaponView weaponView = weaponObject.GetComponentInChildren<WeaponView>();

            weapon.EntityId = entity;
            weapon.Object = weaponObject;
            weapon.Transform = weaponObject.transform;
            weapon.View = weaponView;

            weapon.Owner = unit;
            

            weapon.Barrel.ProjectileAmountModifyer = projectileAmountData;
            weapon.Barrel.ProjectileSizeModifyer = projectileSizeData;
            weapon.Barrel.ProjectileSpeedModifyer = projectileSpeedData;
            weapon.Barrel.ShootPoint = weapon.Transform; // TODO Set correct shoot position

            weapon.Body.ProjectileTypeId = projectileTypeIdData;

            weapon.Scope.VisionRadiusModifyer = visionRadiusData;

            weapon.Stock.RecoilModifyer = recoilData;
            weapon.Stock.ReloadSpeedModifyer = reloadSpeedData;

            return weapon;
        }

        public void CreateEnemy(UnitTypeId enemyTypeId)
        {
            var entity = _world.NewEntity();

            ref var enemy = ref _world
                .GetPool<Unit>()
                .Add(entity);

            var enemyStaticData = _staticDataService.ForUnit(UnitTypeId.Robot);

            Vector3 spawnPosition = Hero.transform.position + Vector3.right * 2;
            
            CreateUnit(enemyStaticData, ref enemy, spawnPosition);

            _world.GetPool<Enemy>().Add(entity);
        }

        private GameObject CreateUnit(UnitStaticData unitStaticData, ref Unit unit, Vector3 position = default)
        {
            GameObject unitObject = Instantiate(unitStaticData.Prefab, position);

            UnitView unitView = unitObject.GetComponent<UnitView>();
            Transform unitTransform = unitObject.transform;
            Transform aim = unitView.aim;
            Transform visual = unitView.visual;

            unit.Object = unitObject;
            unit.Transform = unitTransform;
            unit.Aim = aim;
            unit.Visual = visual;
            unit.Weapon = CreateWeapon(unitObject);
            
            unit.MovementSpeed = unitStaticData.MovementSpeed;

            return unitObject;
        }

        private GameObject Instantiate(GameObject prefab)
        {
            return Object.Instantiate(prefab);
        }

        private GameObject Instantiate(GameObject prefab, Transform parent)
        {
            return Object.Instantiate(prefab, parent);
        }
        
        private GameObject Instantiate(GameObject prefab, Vector3 position)
        {
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}