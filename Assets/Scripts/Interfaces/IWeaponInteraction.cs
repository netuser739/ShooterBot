using UnityEngine;

namespace ShooterBot
{
    public interface IWeaponInteraction
    {
        void WeaponTake(GameObject weapon);
        void WeaponRelease(GameObject weapon);

    }
}