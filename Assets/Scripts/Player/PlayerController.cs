using UnityEngine;

public class PlayerController : MonoBehaviour, IDoDamage
{
    [SerializeField]
    private PlayerStats playerData;

    [SerializeField]
    private Animator animator;

    public void DoDamage(int damage)
    {
        DeathAnimation();
    }

    private void DeathAnimation()
    {
        animator.SetTrigger("IsDead");
        Debug.Log("Player is dead");
    }
}
