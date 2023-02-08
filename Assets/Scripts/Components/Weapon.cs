using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterBot
{
    public class Weapon : MonoBehaviour, IWeapon, IExecute
    {
        [SerializeField] private WeaponCharacteristics characteristics;
        [SerializeField] private Player _player;
        
        private Vector3 _offset;
        private int _damage;
        private float _distance;

        public Weapon(WeaponCharacteristics characteristics)
        {
            _damage = characteristics.Damage;
            _distance = characteristics.Distance;

        }

        private void Awake()
        {
            _offset = Vector3.up * 2f;
        }

        public void Update()
        {
            OnFloor(_player.WithWeapon);
         
        }

        public void Shoot()
        {
            
        }

        public void OnFloor(bool onFloor)
        {
            if (!onFloor) transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*2, 2f), transform.position.z) + _offset;
            else return;
        }

    }
}