using System.Collections.Generic;
using System.Linq;
using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Services.Factory;
using UnityEngine;

internal class ChangeWeaponSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsCustomInject<IGameFactory> _factory;
    
    private EcsFilterInject<Inc<Hero>> _filterHero;

    private EcsPoolInject<Unit> _poolUnit;

    private List<Sprite> _barrels = new List<Sprite>();
    private List<Sprite> _bodies = new List<Sprite>();
    private List<Sprite> _scopes = new List<Sprite>();
    private List<Sprite> _stocks = new List<Sprite>();
    
    public void Init(IEcsSystems systems)
    {
        _barrels = Resources.LoadAll<Sprite>("Weapons/WeaponSprites/Barrel").ToList();
        _bodies = Resources.LoadAll<Sprite>("Weapons/WeaponSprites/Body").ToList();
        _scopes = Resources.LoadAll<Sprite>("Weapons/WeaponSprites/Scope").ToList();
        _stocks = Resources.LoadAll<Sprite>("Weapons/WeaponSprites/Stock").ToList();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var index in _filterHero.Value)
        {
            ref Unit hero = ref _poolUnit.Value.Get(index);

            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                var unit = hero;
                int idx = _barrels.FindIndex(x => unit.Weapon.View.barrel.sprite.texture == x.texture) + 1;

                Debug.Log(idx + "INDEX");
                
                if (idx >= _barrels.Count)
                {
                    idx = 0;
                }
                hero.Weapon.View.barrel.sprite = _barrels[idx];
            }
            
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                var unit = hero;
                int idx = _bodies.FindIndex(x => unit.Weapon.View.body.sprite.texture == x.texture);

                idx++;
                Debug.Log(idx + "INDEX");
                
                if (idx >= _bodies.Count)
                {
                    idx = 0;
                }
                hero.Weapon.View.body.sprite = _bodies[idx];
            }
            
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                var unit = hero;
                int idx = _scopes.FindIndex(x => unit.Weapon.View.scope.sprite.texture == x.texture) + 1;

                Debug.Log(idx + "INDEX");
                
                if (idx >= _scopes.Count)
                {
                    idx = 0;
                }
                hero.Weapon.View.scope.sprite = _scopes[idx];
            }
            
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                var unit = hero;
                int idx = _stocks.FindIndex(x => unit.Weapon.View.stock.sprite.texture == x.texture) + 1;

                Debug.Log(idx + "INDEX");
                
                if (idx >= _stocks.Count)
                {
                    idx = 0;
                }
                hero.Weapon.View.stock.sprite = _stocks[idx];
            }
        }
    }
}