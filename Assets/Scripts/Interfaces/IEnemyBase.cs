using UnityEngine;

namespace ShooterBot
{
    public interface IEnemyBase
    {
        void Move(Vector3 dir);

        void Rotate(Vector3 dir);
    }
}