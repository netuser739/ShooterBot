using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterBot
{
    public class Bullet : MonoBehaviour
    {
        private Transform _rootPool;

        public Transform RootPool
        {
            get
            {
                if(_rootPool == null)
                {
                    var find = GameObject.Find(NameManager.Pool_Amo);
                    _rootPool = find == null ? null : find.transform;
                }

                return _rootPool;
            }
        }

        public void ActiveBullet(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        public void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RootPool);

            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }
    }
}