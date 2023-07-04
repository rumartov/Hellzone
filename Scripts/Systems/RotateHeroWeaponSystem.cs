using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factory;
using UnityEngine;

namespace Systems
{
    internal sealed class RotateWeaponSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Unit, Hero>> _playerFilter = default;
        private readonly EcsPoolInject<Unit> _playerPool = default;
        private readonly EcsWorldInject _world = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var index in _playerFilter.Value)
            {
                ref var unit = ref _playerPool.Value.Get(index);

                RotateWeapon(unit.Aim);
            }
        }

        private void RotateWeapon(Transform aimTransform)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            var aimDirection = -(mousePosition - aimTransform.position).normalized;
            var angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

            aimTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            //Debug.Log(angle);
        }
    }
}