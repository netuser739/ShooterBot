using UnityEngine;

namespace ShooterBot
{
    public interface IWeapon
    {
        void Shoot();

        void OnFloor(bool onfloor);
    }
}