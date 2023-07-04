using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factory;
using UnityEngine;
using static Utils;

namespace Systems
{
    internal sealed class HeroShootSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = default;
        
        private readonly EcsFilterInject<Inc<Hero>> _filterHero = default;

        private readonly EcsPoolInject<Unit> _poolUnit = default;
        private readonly EcsPoolInject<Shooting> _poolShooting = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var index in _filterHero.Value)
            {
                ref Unit hero = ref _poolUnit.Value.Get(index);
                
                int weaponId = hero.Weapon.EntityId;
                
                _poolShooting.Value.Add(weaponId);
            }
        }
    }
}