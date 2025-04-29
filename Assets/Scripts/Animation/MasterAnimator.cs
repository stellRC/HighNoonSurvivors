using System.Collections.Generic;
using UnityEngine;

public class MasterAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator masterAnimator;
    private string currentAnimation;
    AnimatorStateInfo animatorStateInfo;

    public List<string> stateAnimation;
    public List<string> brawlAnimation;

    // private List<string> swordAnimation;
    // private List<string> projectileAnimation;
    public List<string> moveAnimation;

    public bool animationFinished;

    private float NTime;

    void Awake() { }

    void OnEnable()
    {
        // masterAnimator = GetComponentInChildren<Animator>();
        InitAnimationLists();
    }

    private void InitAnimationLists()
    {
        stateAnimation = new List<string>()
        {
            "Die",
            "Stunned",
            "HitDamage",
            "HitDamageUp",
            "Knockback"
        };

        brawlAnimation = new List<string>() { "PunchA", "PunchB", "PunchC", "KickA", "KickB" };
        moveAnimation = new List<string>() { "Idle", "Walk", "Run", "Sprint", "Dash" };
        // projectileAnimation = new List<string>() {}
    }

    void Update()
    {
        animatorStateInfo = masterAnimator.GetCurrentAnimatorStateInfo(0);
        NTime = animatorStateInfo.normalizedTime;

        if (NTime >= 1.0f)
        {
            animationFinished = true;
        }
        else
        {
            animationFinished = false;
        }
    }

    public void ChangeAnimation(string animation, float crossFade = 0.2f)
    {
        if (currentAnimation != animation && animationFinished)
        {
            currentAnimation = animation;
            masterAnimator.CrossFade(animation, crossFade);
        }
    }
}
