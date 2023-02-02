using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using ServiceLocator;
using Object = UnityEngine.Object;

namespace ShooterBot
{
    internal sealed class AmoPool : ServiceBase
    {
        private readonly Dictionary<string, HashSet<Bullet>> _amoPool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public AmoPool(int capacityPool, int version) : base(version)
        {
            _amoPool = new Dictionary<string, HashSet<Bullet>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.Pool_Amo).transform;
            }
        }

        public Bullet GetBullet(BulletType type) 
        {
            Bullet result;
            switch(type)
            {
                case BulletType.DefaultBullet:
                    result = GetAmmo(GetListBullets(BulletType.DefaultBullet));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не существует");
            }

            return result;
        }

        private HashSet<Bullet> GetListBullets(BulletType type)
        {
            return _amoPool.ContainsKey(type.ToString()) ? _amoPool[type.ToString()] : 
                _amoPool[type.ToString()] = new HashSet<Bullet>();
        }

        private Bullet GetAmmo(HashSet<Bullet> bullets) 
        {
            var bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            if(bullets == null)
            {
                var laser = Resources.Load<Bullet>("Bullet");
                for(int i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform);
                    bullets.Add(instantiate);
                }
                GetAmmo(bullets);
            }
            bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            return bullet;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}