using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factory;
using UnityEngine;

namespace Systems
{
    public sealed class CameraFollowHeroSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<Unit, Hero>> _filterHero;
        private EcsPoolInject<Unit> _poolHero;

        public void Run(IEcsSystems systems)
        {
            foreach (var index in _filterHero.Value)
            {
                var unit = _poolHero.Value.Get(index);
                SetNewCameraPosition(unit);
            }
        }

        private static void SetNewCameraPosition(Unit unit)
        {
            var heroPosition = unit.Transform.position;
            var cameraNewPosition = new Vector3(heroPosition.x, heroPosition.y, -20);
            Camera.main.transform.position = cameraNewPosition;
        }
    }
}