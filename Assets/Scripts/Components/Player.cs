using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ShooterBot
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : Unit
    {
        private CharacterController characterController;

        public override void Awake()
        {
            base.Awake();

            characterController = GetComponent<CharacterController>();
            

        }

        public override void Animation(Animator animator, float speed)
        {
            animator.SetFloat("Speed", speed);
        }

        public override void Move(Vector3 direction)
        {
            direction.y -= Mathf.Sqrt(2 * this.Gravity);
            characterController.Move(direction * Speed * Time.deltaTime);

        }

        public override void Rotate(Vector3 direction)
        {
            Vector3 move = Vector3.ClampMagnitude(direction, 1);
            if (move.magnitude > Mathf.Abs(0.05f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * 20);
        }

        public override void Shoot()
        {
            
        }
    }
}