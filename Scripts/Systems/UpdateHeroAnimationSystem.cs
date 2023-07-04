using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factory;
using Services.Input;
using UnityComponents.Animation;

internal sealed class UpdateHeroAnimationSystem : IEcsRunSystem
{
    private readonly EcsWorldInject _world = default;

    private readonly EcsFilterInject<Inc<Unit, Hero>> _filterUnit = default;
    private readonly EcsFilterInject<Inc<UpdateHeroAnimation>> _filterUpdateAnimation = default;

    private readonly EcsPoolInject<Unit> _poolUnit = default;
    private readonly EcsPoolInject<UpdateHeroAnimation> _poolUpdateAnimation = default;

    private readonly EcsCustomInject<IGameFactory> _factory = default;
    private readonly EcsCustomInject<IInputService> _inputService = default;

    public void Run(IEcsSystems systems)
    {
        foreach (var index in _filterUpdateAnimation.Value)
        {
            ref Unit unit = ref _poolUnit.Value.Get(index);
            ref UpdateHeroAnimation updateHeroAnimation = ref _poolUpdateAnimation.Value.Get(index);

            switch (updateHeroAnimation.AnimationState)
            {
                case HeroAnimationState.Idle:
                    unit.Object.GetComponentInChildren<HeroAnimator>().Idle();
                    break;
                case HeroAnimationState.Walk:
                    unit.Object.GetComponentInChildren<HeroAnimator>().Walk();
                    break;
            }
        }
    }
}