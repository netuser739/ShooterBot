using ShooterBot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototype;    //не забыть убрать

namespace ShooterBot
{
    public class EnemyFactory : IEnemyFactory
    {
        public Enemy Create(EnemyType type)
        {
            Enemy enemy;

            switch (type)
            {
                case EnemyType.SpiderBot:
                    enemy = Object.Instantiate(Resources.Load<Enemy>("SpiderBot"));
                    return enemy;
            }

            return null;
        }

        //все убрать
        public EnemyData Copy(Enemy enemy)
        {
            EnemyData data = new EnemyData(enemy);
            EnemyData newEnemyData = data.DeepCopy();
            return newEnemyData;
        }
    }
}