using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factory;
using Services.Input;
using UnityEngine;

namespace Systems
{
    internal sealed class HeroMoveSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = default;
        
        private readonly EcsFilterInject<Inc<Unit, Hero>> _filterUnit = default;

        private readonly EcsPoolInject<Unit> _poolUnit = default;
        private readonly EcsPoolInject<UpdateHeroAnimation> _poolUpdateAnimation = default;

        private readonly EcsCustomInject<IGameFactory> _factory = default;
        private readonly EcsCustomInject<IInputService> _inputService = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var index in _filterUnit.Value)
            {
                ref Unit hero = ref _poolUnit.Value.Get(index);
                if (Utils.HeroIsMoving(_inputService.Value))
                {
                    MoveHero(hero.MovementSpeed);

                    UpdateAnimationState(index, HeroAnimationState.Walk);
                }
                else
                {
                    UpdateAnimationState(index, HeroAnimationState.Idle);
                }
            }
        }

        private void UpdateAnimationState(int index, HeroAnimationState animationState)
        {
            ref UpdateHeroAnimation updateHeroAnimation = ref _poolUpdateAnimation.Value.Add(index);
            updateHeroAnimation.AnimationState = animationState;
        }

        private void MoveHero(float moveSpeed)
        {
            var movementVector = Camera.main.transform.TransformDirection(_inputService.Value.Axis);
            movementVector.Normalize();

            _factory.Value.Hero.transform.rotation = Quaternion.Euler(0, movementVector.y, 0);
            _factory.Value.Hero.transform.Translate(moveSpeed * movementVector * Time.deltaTime);
        }
    }
}