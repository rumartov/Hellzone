using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.ExtendedSystems;
using Leopotam.EcsLite.UnityEditor;
using Services.Factory;
using Services.Input;
using Services.StaticData;
using Systems;
using UnityEngine;

internal class EcsStartup : MonoBehaviour
{
    private IGameFactory _factory;
    private IInputService _inputService;

    private IStaticDataService _staticDataService;
    private IEcsSystems _systems;
    private EcsWorld _world;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        InitServices();

        InitSystems();
    }

    private void Update()
    {
        _systems?.Run();
    }

    private void OnDestroy()
    {
        if (_systems != null)
        {
            _systems.Destroy();
            _systems = null;
        }

        if (_world != null)
        {
            _world.Destroy();
            _world = null;
        }
    }

    private void InitServices()
    {
        InitializeInputService();
        InitializeStaticDataService();

        _factory = new GameFactory(_world, _staticDataService);
    }

    private void InitializeInputService()
    {
        if (Application.isMobilePlatform)
            _inputService = new MobileInputService();
        else
            _inputService = new StandaloneInputService();
    }

    private void InitializeStaticDataService()
    {
        _staticDataService = new StaticDataService();
        _staticDataService.Load();
    }

    private void InitSystems()
    {
        _systems
            .Add(new InitGameSystem())
            .Add(new HeroMoveSystem())
            .Add(new HeroFlipSystem())
            .Add(new HeroShootSystem())
                
            .Add(new RotateWeaponSystem())
            .Add(new CameraFollowHeroSystem())
            .Add(new EnemyMoveSystem())
            .Add(new EnemyFlipSystem())
            
            .Add(new UpdateHeroAnimationSystem())
            
            .Add(new ChangeWeaponSystem())
            
            .Add(new ShootingSystem())
            .Add(new MoveBulletSystem())
            
            .DelHere<UpdateHeroAnimation>()
            .DelHere<Shooting>()
#if UNITY_EDITOR
            .Add(new EcsWorldDebugSystem())
#endif
            .Inject(_factory, _inputService)
            .Init();
    }
}