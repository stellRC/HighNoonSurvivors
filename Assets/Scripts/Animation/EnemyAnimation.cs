using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator spriteAnimator;

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
            // Dash
            case 4:
                spriteAnimator.SetInteger("AnimState", 4);

                break;
            // Hurt
            case 5:
                spriteAnimator.SetTrigger("Hurt");

                break;
            // Death
            case 6:
                spriteAnimator.SetBool("IsDead", true);

                break;
            // Sword Attack
            case 7:
                spriteAnimator.SetTrigger("SwordRunSlash");

                break;
            case 8:
                spriteAnimator.SetTrigger("BowPreview");

                break;
            case 9:
                spriteAnimator.SetTrigger("GunPreview");

                break;
        }
    }
}
