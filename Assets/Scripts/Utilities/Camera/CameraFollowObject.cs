using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform playerTransform;

    [Header("Flip Rotation Stats")]
    [SerializeField]
    private float flipYRotationTime = 0.5f;

    private PlayerMovement playerMovement;
    private bool isFacingRight;

    private void Awake()
    {
        playerMovement = playerTransform.gameObject.GetComponent<PlayerMovement>();
        isFacingRight = playerMovement.IsFacingRight;
    }

    private void FixedUpdate()
    {
        // make cameraFollowObject follow player's position
        transform.position = playerTransform.position;
    }

    public void CallTurn()
    {
        LeanTween.rotateY(gameObject, DetermineEndRotation(), flipYRotationTime).setEaseInOutSine();
    }

    private float DetermineEndRotation()
    {
        isFacingRight = !isFacingRight;
        if (isFacingRight)
        {
            return 180f;
        }
        else
        {
            return 0f;
        }
    }
}
