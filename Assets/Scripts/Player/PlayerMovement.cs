using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // New Input System
    public InputSystem_Actions playerControls;
    private InputAction Move;

    // Normal movement code stuff
    public float moveSpeed;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Tracks direction
    public bool FacingDown = false;
    public bool FacingUp = false;
    public bool FacingRight = false;
    public bool FacingLeft = false;


    private void Awake()
    {
        //animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerControls = new InputSystem_Actions();
    }
    private void OnEnable()
    {
        Move = playerControls.Player.Move;
        Move.Enable();
    }
    private void OnDisable()
    {
        Move.Disable();
    }

    private void Update()
    {
        PlayerInputHandler.MoveInput = Move.ReadValue<Vector2>();

        /// implementation of animations for later

        // if input is not null
        if (PlayerInputHandler.MoveInput != Vector2.zero)
        {
           // make the animation set to walking
           // UpdateAnimationDirection();
        }
        else
        {
           // and the animation for idling is set
           // animator.SetBool("isMoving", false);
        }

        FlipSpriteOnDestination();
        //LookDirection();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = PlayerInputHandler.MoveInput + new Vector2(PlayerInputHandler.MoveInput.x, PlayerInputHandler.MoveInput.y) * moveSpeed;
    }

    private void UpdateAnimationDirection()
    {

        // Set the animation parameters based on animationIndex
        animator.SetFloat("moveX", PlayerInputHandler.MoveInput.x);
        animator.SetFloat("moveY", PlayerInputHandler.MoveInput.y);
        animator.SetBool("isMoving", true);

    }

    public void LookDirection()
    {
        /// it will probably be useful to know which way the player is facing later in development

        if (PlayerInputHandler.MoveInput.y <= -0.0000001f)
        {
            FacingDown = true;
            Debug.Log("down");
        }
        else { FacingDown = false; }

        if (PlayerInputHandler.MoveInput.y >= 0.0000001f)
        {
            FacingUp = true;
            Debug.Log("up");
        }
        else { FacingUp = false; }

        if (PlayerInputHandler.MoveInput.x <= -0.0000001f)
        {
            FacingLeft = true;
            Debug.Log("left");
        }
        else { FacingLeft = false; }

        if (PlayerInputHandler.MoveInput.x >= 0.0000001f)
        {
            FacingRight = true;
            Debug.Log("right");
        }
        else { FacingRight = false; }

    }
    private void FlipSpriteOnDestination()
    {
        float velocity = PlayerInputHandler.MoveInput.x;
            
        if (Mathf.Abs(velocity) > 0.01f) 
        {
            sr.flipX = velocity < 0;
        }
    }

}
