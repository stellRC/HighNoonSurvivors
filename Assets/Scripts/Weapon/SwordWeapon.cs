public class SwordWeapon : WeaponBase
{
    public SwordWeapon()
    {
        damage = 2;
        damageType = new ProjectileDamage();
    }
}
