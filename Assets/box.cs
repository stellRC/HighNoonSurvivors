using UnityEngine;

public class box : MonoBehaviour
{
    void Start()
    {
        LeanTween.moveY(gameObject, 10, 2).setEaseInOutCubic().setLoopPingPong();
    }
}
