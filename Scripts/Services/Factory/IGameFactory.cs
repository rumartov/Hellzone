using Components;
using StaticData;
using UnityEngine;

namespace Services.Factory
{
    public interface IGameFactory
    {
        GameObject Hero { get; set; }
        void CreateHero();
        void CreateBullet(Vector3 startPoint, Vector3 direction, float speedModifyer, float range);
        Weapon CreateWeapon(GameObject unit);
        void CreateEnemy(UnitTypeId enemyTypeId);
    }
}