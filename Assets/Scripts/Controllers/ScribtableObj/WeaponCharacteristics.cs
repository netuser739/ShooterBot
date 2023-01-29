using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponCharacteristics", menuName = "Weapon / Characteristics", order = 1)]
public class WeaponCharacteristics : ScriptableObject
{
    private int _damage = 10;
    private float _distance = 20f;

    public int Damage => _damage;
    public float Distance => _distance;
}
