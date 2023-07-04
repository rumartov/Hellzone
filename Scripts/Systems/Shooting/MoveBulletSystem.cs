using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factory;
using UnityEngine;

internal sealed class MoveBulletSystem : IEcsRunSystem
{
    private readonly EcsWorldInject _world = default;
    private readonly EcsFilterInject<Inc<Bullet>> _filterBullet = default;
    private readonly EcsPoolInject<Bullet> _poolBullet = default;
    private readonly EcsCustomInject<IGameFactory> _factory = default;

    public void Run(IEcsSystems systems)
    {
        foreach (var index in _filterBullet.Value)
        {
            ref Bullet bullet = ref _poolBullet.Value.Get(index);
            
            MoveBullet(bullet.Object, bullet.Direction, bullet.Speed);
        }
    }

    private void MoveBullet(GameObject bulletObject, Vector3 direction, float speed)
    {
        bulletObject.transform.position += direction * speed * Time.deltaTime;
    }

}