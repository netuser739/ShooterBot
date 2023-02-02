using ShooterBot;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    [Serializable]
    public class EnemyData
    {
        public EnemyType type;
        public int health;
        public float speed;
        public int damage;
        public bool isFly;

        public EnemyData(Enemy enemy)
        {
            type = enemy.characteristics.Type;
            health = enemy.characteristics.Health;
            speed = enemy.characteristics.Speed;
            damage = enemy.characteristics.Damage;
            isFly = enemy.characteristics.IsFly;
        }

        public override string ToString()
        {
            return $"{speed}, {health}, {damage}";
        }
    }
}