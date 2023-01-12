using UnityEngine;

namespace ShooterBot
{
    public interface IBaseControl
    {
        void Animation(Animator animator, float speed);

        void Move(Vector3 direction);

        void Rotate(Vector3 direction);

        void Shoot();
    }
}