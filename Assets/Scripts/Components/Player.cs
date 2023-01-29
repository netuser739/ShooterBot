using ShooterBot;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ShooterBot
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : Unit, IWeaponInteraction
    {
        [SerializeField] private GameObject _weaponPoint;
        private CharacterController characterController;

        private GameObject[] _weapons;
        private bool _weaponGrab;
        private Collider _weaponCollider;
        private bool _withWeapon;
        private bool _aming;

        public bool WeaponGrab => _weaponGrab;

        public Collider WeaponCollider => _weaponCollider;

        public bool WithWeapon => _withWeapon;

        public bool Aming { get => _aming; set => _aming = value; }

        public override void Awake()
        {
            base.Awake();

            characterController = GetComponent<CharacterController>();
            _weapons = new GameObject[] {null, null};

            _weaponGrab = false;
            _withWeapon = false;
            _aming = false;
        }

        public override void Animation(Animator animator, float speed)
        {
            animator.SetFloat("Speed", speed);
            animator.SetBool("Aming", _aming);

            if (_withWeapon)
            { 
                animator.SetLayerWeight(1, 1);
                if (_aming)
                {
                    animator.SetLayerWeight(2, 1);
                }
                else animator.SetLayerWeight(2, 0);
            }
            else animator.SetLayerWeight(1, 0);
            
            

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

        public void WeaponTake(GameObject obj)
        {
            //if (_weapons[0] == null)
            //{
            //    _weapons[0] = obj;
            //}
            //else if (_weapons[1] == null)
            //{
            //    _weapons[1] = obj;
            //}
            //else return;
            obj.GetComponent<Animator>().enabled = false;
            obj.GetComponent<Collider>().enabled = false;
            obj.transform.parent = _weaponPoint.transform;
            obj.transform.localPosition = new Vector3(0.04258f, 0.01322f, 0.00170f);
            obj.transform.localRotation = new Quaternion(0.84743f, 0.27182f, -0.45598f, 0.00696f);
            _withWeapon = true;
        }

        public void WeaponRelease(GameObject obj)
        {
            
            obj.GetComponent<Animator>().enabled = true;
            obj.GetComponent<Collider>().enabled = true;
            obj.transform.parent = null;
            obj.transform.rotation = new Quaternion(-0.70710f, 0f, 0f, 0.70710f);
            _withWeapon = false;
        }

        public override void Shoot()
        {
            
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Weapon")
            {
                _weaponGrab = true;
                _weaponCollider = other;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Weapon")
            {
                _weaponGrab = false;
                _weaponCollider = null;
            }
        }
    }
}