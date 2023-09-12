using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;

    public float runSpeed = 20.0f;
    private float moveLimiter = 0.7f;

    private float horizontal;
    private float vertical;

    public bool canMove = true;  

    private const string RUN_WEST = "RunWest";
    private const string RUN_EAST = "RunEast";
    private const string RUN_SOUTH = "RunSouth";
    private const string RUN_NORTH = "RunNorth";
    private const string IDLE_SOUTH = "IdleSouth";
    private const string IDLE_NORTH = "IdleNorth";
    private const string IDLE_EAST = "IdleEast";
    private const string IDLE_WEST = "IdleWest";

    public string currentAnimation;

    private void OnEnable()
    {
        DialogController.InitiateDialog += StopMovement;
    }
    private void OnDisable()
    {
        DialogController.InitiateDialog += StopMovement;
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SetAnimation(IDLE_SOUTH);
    }

    void Update()
    {
        if (!canMove)
        {
            horizontal = 0;
            vertical = 0;
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (!canMove) return;

        MoveCharacter();
        HandleAnimations();
    }

    private void MoveCharacter()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void HandleAnimations()
    {
        if (horizontal == 0 && vertical == 0)
        {
            if (currentAnimation == RUN_SOUTH) SetAnimation(IDLE_SOUTH);
            else if (currentAnimation == RUN_NORTH) SetAnimation(IDLE_NORTH);
            else if (currentAnimation == RUN_EAST) SetAnimation(IDLE_EAST);
            else if (currentAnimation == RUN_WEST) SetAnimation(IDLE_WEST);
            return;
        }

        if (vertical == -1) SetAnimation(RUN_SOUTH);
        else if (vertical == 1) SetAnimation(RUN_NORTH);
        else if (horizontal == -1) SetAnimation(RUN_WEST);
        else if (horizontal == 1) SetAnimation(RUN_EAST);
    }
    private void SetAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }

    private void StopMovement()
    {
        canMove = false;
    }
    private void ActivateMovement()
    {
        canMove = true;
    }
}
