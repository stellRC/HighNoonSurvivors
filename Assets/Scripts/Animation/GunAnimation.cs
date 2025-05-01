using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator spriteAnimator;

    // Animation States
    public void SetAnimation(int animationId)
    {
        switch (animationId)
        {
            // Idle
            case 1:
                spriteAnimator.SetInteger("AnimState", 1);
                break;

            // Walk
            case 2:
                spriteAnimator.SetInteger("AnimState", 2);
                break;

            // Run
            case 3:
                spriteAnimator.SetInteger("AnimState", 3);
                break;

            // Sprint
            case 4:
                spriteAnimator.SetInteger("AnimState", 4);
                break;

            // Dash
            case 5:
                spriteAnimator.SetInteger("AnimState", 5);
                break;

            // Crouch
            case 6:
                spriteAnimator.SetBool("IsCrouching", true);
                break;

            // Death
            case 7:
                spriteAnimator.SetBool("IsDead", true);
                break;

            // Sprint Fire
            case 8:
                spriteAnimator.SetTrigger("GunSprintFire");
                break;

            // Run Fire
            case 9:
                spriteAnimator.SetTrigger("GunRunFire");
                // gameObject.GetComponentInParent<ProjectileWeapon>().InstantiateProjectile();
                break;

            // Walk Fire
            case 10:
                spriteAnimator.SetTrigger("GunWalkFire");
                break;

            // Idle Fire
            case 11:
                spriteAnimator.SetTrigger("GunFire");
                break;

            // Stunned
            case 12:
                spriteAnimator.SetTrigger("Stunned");
                break;

            // Knockback
            case 13:
                spriteAnimator.SetTrigger("Knockback");
                break;

            // Hit Damage
            case 14:
                spriteAnimator.SetTrigger("HitDamage");
                break;

            // Hit Damage Up
            case 15:
                spriteAnimator.SetTrigger("HitDamageUp");
                break;

            // Crouch Fire
            case 16:
                spriteAnimator.SetTrigger("GunCrouchFire");
                break;

            // Reload
            case 17:
                spriteAnimator.SetTrigger("GunReload");
                break;
        }
    }
}
