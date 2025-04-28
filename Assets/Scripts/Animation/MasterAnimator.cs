using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterAnimator : MonoBehaviour
{
    private Animator masterAnimator;
    private string currentAnimation;

    Dictionary<string, string> animationDictionary =
        new()
        {
            // { key1, value1 },
            // { key2, value2 }
        };

    // Start is called before the first frame update
    void Start()
    {
        masterAnimator = GetComponent<Animator>();
    }

    private void CheckAnimation() { }

    private void ChangeAnimation(string animation, float crossFade = 0.2f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            masterAnimator.CrossFade(animation, crossFade);
        }
    }
}
