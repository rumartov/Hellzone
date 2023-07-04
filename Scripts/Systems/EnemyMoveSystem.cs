using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factory;
using UnityEngine;

namespace Systems
{
    internal sealed class EnemyMoveSystem : IEcsRunSystem
    {
        private EcsCustomInject<IGameFactory> _factory;
        private EcsFilterInject<Inc<Unit, Enemy>> _filterEnemy;

        private EcsPoolInject<Unit> _poolEnemy;

        public void Run(IEcsSystems systems)
        {
            foreach (var index in _filterEnemy.Value)
            {
                ref Unit enemy = ref _poolEnemy.Value.Get(index);
                MoveEnemy(ref enemy.Transform, _factory.Value.Hero.transform.position, enemy.MovementSpeed);
            }
        }

        private void MoveEnemy(ref Transform enemyTransform, Vector3 heroPosition, float moveSpeed)
        {
            var movementVector = Camera.main.transform.TransformDirection(heroPosition - enemyTransform.position);
            movementVector.Normalize();

            enemyTransform.rotation = Quaternion.Euler(0, movementVector.y, 0);
            enemyTransform.Translate(moveSpeed * movementVector * Time.deltaTime);
        }
    }
}