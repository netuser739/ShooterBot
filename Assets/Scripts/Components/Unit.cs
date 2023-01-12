using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterBot
{
    public abstract class Unit : MonoBehaviour, IBaseControl
    {
        [SerializeField] private UnitCharacteristics _characteristics;

        private Animator _animator;
        private Transform _transform;
        private int _health;
        private float _speed;
        private int _damage;
        private bool _isDead;
        private float _gravity;

        public int Health 
        { 
            get => _health;
            set 
            {
                if(value >= 0 && value <= 100) _health = value;
                else _health = 100;
            } 
        }

        public float Speed { get => _speed; set => _speed = value; }
        public int Damage { get => _damage; set => _damage = value; }
        public bool IsDead { get => _isDead; set => _isDead = value; }
        public Vector3 Position { get => _transform.position; }
        public RuntimeAnimatorController AnimatorController { get => Animator.runtimeAnimatorController; set => Animator.runtimeAnimatorController = value; }
        public float Gravity { get => _gravity; set => _gravity = value; }
        public Animator Animator { get => _animator; set => _animator = value; }

        public virtual void Awake()
        {
            if (!TryGetComponent<Transform>(out _transform)) Debug.Log("Not Component Transform");
            if (!TryGetComponent<Animator>(out _animator)) Debug.Log("Not Component Animator");

            Speed = _characteristics.MovementSpeed;
            Health = _characteristics.Health;
            AnimatorController = _characteristics.Animator;
            Gravity = _characteristics.Gravity;
        }

        public abstract void Animation(Animator animator, float speed);

        public abstract void Move(Vector3 direction);

        public abstract void Rotate(Vector3 direction);

        public abstract void Shoot();
    }
}
