using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factory;
using UnityEngine;

internal sealed class EnemyFlipSystem : IEcsRunSystem
{
    private EcsCustomInject<IGameFactory> _factory;
    private EcsFilterInject<Inc<Unit, Enemy>> _filterEnemy;

    private EcsPoolInject<Unit> _poolEnemy;

    public void Run(IEcsSystems systems)
    {
        foreach (var index in _filterEnemy.Value)
        {
            ref Unit enemy = ref _poolEnemy.Value.Get(index);

            Vector3 direction = _factory.Value.Hero.transform.position - enemy.Transform.position;
            float angleBetweenEnemyEndHero = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            Utils.FlipTransform(ref enemy.Transform, angleBetweenEnemyEndHero, Utils.FlipAxis.Y,
                0f, -180f);
        }
    }
}