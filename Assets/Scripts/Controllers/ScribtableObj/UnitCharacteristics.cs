using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterBot
{
    [CreateAssetMenu(fileName = "UnitCharacteristics", menuName = "Unit / Characteristics", order = 1)]
    public class UnitCharacteristics : ScriptableObject
    {
        [SerializeField] private RuntimeAnimatorController animator;
        [SerializeField] private int health = 100;
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private float angularSpeed = 150f;
        [SerializeField] private float gravity = 15f;

        public float MovementSpeed => movementSpeed;
        public float AngularSpeed => angularSpeed;
        public float Gravity => gravity;
        public RuntimeAnimatorController Animator => animator;
        public int Health { get => health; set => health = value; }
    }
}