using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer playerSprite;

    [SerializeField]
    private Animator playerSpriteAnimator;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private CameraFollowObject cameraFollowObject;

    public bool IsFacingRight { get; set; }
    private Rigidbody2D playerRigidBody;

    private bool isDashing;

    private bool isMoving;
    private Vector2 moveInput;

    //DASH
    private float activeMoveSpeed;
    private float dashSpeed;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        isDashing = false;

        isMoving = false;

        activeMoveSpeed = moveSpeed;
        dashSpeed = 7f;
    }

    private void Update()
    {
        // Idle
        if (!isDashing & !isMoving)
        {
            playerSpriteAnimator.SetInteger("AnimState", 1);
            activeMoveSpeed = moveSpeed;
        }

        // Running
        if (!isDashing & isMoving)
        {
            playerSpriteAnimator.SetInteger("AnimState", 2);
            activeMoveSpeed = moveSpeed;
        }
    }

    //good to use fixed update for rigid body objects
    void FixedUpdate()
    {
        playerRigidBody.velocity = moveInput * activeMoveSpeed;

        if (playerRigidBody.velocity.x == 0 & playerRigidBody.velocity.y == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        if (moveInput.x > 0 || moveInput.x < 0)
        {
            TurnCheck(moveInput);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void TurnCheck(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            Turn();
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        if (IsFacingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;

            //turn camera follow object
            cameraFollowObject.CallTurn();
        }
        else
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;

            //turn camera follow object
            cameraFollowObject.CallTurn();
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isDashing = !isDashing;
            playerSpriteAnimator.SetInteger("AnimState", 3);
            activeMoveSpeed = dashSpeed;
        }

        if (context.canceled)
        {
            isDashing = !isDashing;
        }
    }
}
