using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : WeaponBase
{
    public SwordWeapon()
    {
        damage = 2;
        damageType = new ProjectileDamage();
    }
}
