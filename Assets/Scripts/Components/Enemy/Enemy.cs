using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterBot
{
    public abstract class Enemy : MonoBehaviour, IEnemyBase, IWork
    {
        [SerializeField] public EnemyCharacteristics characteristics;       //не забыть поменять на private

        private EnemyType _type;
        private RuntimeAnimatorController _animator;
        private int _health;
        protected float _speed;
        private float _viewRadius;
        private int _damage;
        private bool _isFly;

        public virtual void Awake()
        {
            _type = characteristics.Type;
            _animator = characteristics.Animator;
            _health = characteristics.Health;
            _speed = characteristics.Speed;
            _damage = characteristics.Damage;
            _isFly = characteristics.IsFly;
        }

        public abstract void Move(Vector3 dir);

        public abstract void Rotate(Vector3 dir);

        public abstract void Animation(Animator animator, float speed);

        public static Vector3 RandomDir()
        {
            return Vector3.Normalize(new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)));
        }

        public abstract void Work();
    }
}