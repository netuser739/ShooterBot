using ShooterBot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}