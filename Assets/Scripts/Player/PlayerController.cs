using UnityEngine;

public class PlayerController : MonoBehaviour, IDoDamage
{
    [SerializeField]
    private PlayerStats playerData;

    [SerializeField]
    private Animator animator;

    public bool IsDead;

    void Start()
    {
        IsDead = false;
    }

    public void DoDamage(int damage)
    {
        DeathAnimation();
        IsDead = true;
    }

    private void DeathAnimation()
    {
        animator.SetTrigger("IsDead");
        Debug.Log("Player is dead");
    }
}
