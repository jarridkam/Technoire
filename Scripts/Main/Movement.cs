using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;

    public float horizontal;
    public float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    private Animator animator;
    const string RUN_WEST = "RunWest";
    const string RUN_EAST = "RunEast";
    const string RUN_SOUTH = "RunSouth";
    const string RUN_NORTH = "RunNorth";
    const string IDLE_SOUTH = "IdleSouth";
    const string IDLE_NORTH = "IdleNorth";
    const string IDLE_EAST = "IdleEast";
    const string IDLE_WEST = "IdleWest";
    
    public string currentAnimation;

    private void Awake()
    {

        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AnimationChanger(IDLE_SOUTH);
    }

    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal"); 
        vertical = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) 
        {
            
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        if (horizontal == 0 && vertical == 0 && currentAnimation == RUN_SOUTH)
            AnimationChanger(IDLE_SOUTH);
        
        if (horizontal == 0 && vertical == 0 && currentAnimation == RUN_NORTH)
            AnimationChanger(IDLE_NORTH);
        
        if (horizontal == 0 && vertical == 0 && currentAnimation == RUN_EAST)
           AnimationChanger(IDLE_EAST);

        if (horizontal == 0 && vertical == 0 && currentAnimation == RUN_WEST)
            AnimationChanger(IDLE_WEST);

        if (vertical == -1)
        {
            AnimationChanger(RUN_SOUTH);
        }
        
        if (vertical == 1)
        {
            AnimationChanger(RUN_NORTH);
        }
        
        if (horizontal == -1)
        {
            AnimationChanger(RUN_WEST);
        }


        if (horizontal == 1)
        {
            AnimationChanger(RUN_EAST);
        }
        
       
    }

    void AnimationChanger(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        {
            animator.Play(newAnimation);
            currentAnimation = newAnimation;
        }
    }
   
}
