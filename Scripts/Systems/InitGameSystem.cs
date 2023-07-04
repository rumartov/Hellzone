using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factory;

namespace Systems
{
    internal sealed class InitGameSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<IGameFactory> _factory = default;

        public void Init(IEcsSystems systems)
        {
            _factory.Value.CreateHero();
            //_factory.Value.CreateEnemy(UnitTypeId.Robot);
        }
    }
}