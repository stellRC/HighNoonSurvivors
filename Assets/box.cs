using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    void Start()
    {
        LeanTween.moveY(gameObject, 10, 2).setEaseInOutCubic().setLoopPingPong();
    }
}
