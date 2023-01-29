using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterBot
{
    [CreateAssetMenu(fileName = "EnemyCharacteristics", order = 0)]
    public class EnemyCharacteristics : ScriptableObject
    {
        [SerializeField] private EnemyType type;
        [SerializeField] private RuntimeAnimatorController animator;
        [SerializeField] private int health;
        [SerializeField] private float speed;
        [SerializeField] private int damage;
        [SerializeField] private bool isFly;

        public EnemyType Type => type;
        public RuntimeAnimatorController Animator => animator;
        public int Health => health;
        public float Speed => speed;
        public int Damage => damage;
        public bool IsFly => isFly;

    }
}