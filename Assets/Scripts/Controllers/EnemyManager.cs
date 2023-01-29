using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ShooterBot
{
    public class EnemyManager
    {
        private SpiderBot[] spiderBots;

        public EnemyManager() 
        {
            spiderBots = GameObject.FindObjectsOfType<SpiderBot>();
        }

        public SpiderBot[] SpiderBots => spiderBots;

        private IEnemyFactory enemyFactory = new EnemyFactory();

    }
}