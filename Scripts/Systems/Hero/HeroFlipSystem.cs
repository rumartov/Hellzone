using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using static Utils;

namespace Systems
{
    internal sealed class HeroFlipSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Components.Unit>> _filterHero = default;

        private readonly EcsPoolInject<Components.Unit> _poolHero = default;
        private readonly EcsWorldInject _world = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var index in _filterHero.Value)
            {
                ref var unit = ref _poolHero.Value.Get(index);

                var aimRotationZ = unit.Aim.eulerAngles.z;

                Debug.Log(aimRotationZ);

                var weaponTransform = unit.Aim.GetChild(0);

                FlipTransform(ref weaponTransform, aimRotationZ, FlipAxis.X,
                    -180f, 0f);
                FlipTransform(ref unit.Visual, aimRotationZ, FlipAxis.Y,
                    0, -180);
            }
        }
    }
}