using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterBot
{
    public class SpiderBot : Enemy
    {
        float time = 12f;
        Vector3 dir;

        public override void Awake()
        {
            base.Awake();
        }

        public override void Move(Vector3 dir)
        {
            transform.position += dir * _speed * Time.deltaTime;
        }

        public override void Rotate(Vector3 dir)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.Cross(dir, Vector3.down)), 2f * Time.deltaTime);
        }

        public override void Animation(Animator animator, float speed)
        {
            
        }

        public override void Work()
        {
            if (time > 15f)
            {
                dir = Enemy.RandomDir();
                time = 0f;
            }

            time += Time.deltaTime;
            Move(dir);
            Rotate(dir);
        }

    }
}