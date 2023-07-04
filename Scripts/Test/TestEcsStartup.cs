using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;

internal class TestEcsStartup : MonoBehaviour
{
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
    }

    private void InitSystems()
    {
        _systems
            //.Add()
            
#if UNITY_EDITOR
            .Add(new EcsWorldDebugSystem())
#endif
            .Inject()
            .Init();
    }
}