using UnityEngine;

public class Movement : MonoBehaviour
{

    // Normal movement code stuff
    public float moveSpeed;
    private Vector2 input;
    private Animator animator;
    private Rigidbody2D rb;

    // Tracks direction
    public bool FacingDown = false;
    public bool FacingUp = false;
    public bool FacingRight = false;
    public bool FacingLeft = false;


    private void Awake()
    {
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        input = Vector3.Normalize(input);

        // if input is not null
        if (input != Vector2.zero)
        {
           /// We un-comment these when we have animations
           // UpdateAnimationDirection();
        }
        else  
        {
           // animator.SetBool("isMoving", false);
        }

        LookDirection();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }

    private void UpdateAnimationDirection()
    {
        // Set the animation parameters based on animationIndex
        animator.SetFloat("moveX", input.x);
        animator.SetFloat("moveY", input.y);
        animator.SetBool("isMoving", true);
    }

    public void LookDirection()
    {

        if (input.y <= -0.001f)
        {
            FacingDown = true;
            //Debug.Log("down");
        }
        else { FacingDown = false; }

        if (input.y >= 0.001f)
        {
            FacingUp = true;
            //Debug.Log("up");
        }
        else { FacingUp = false; }

        if (input.x <= -0.001f)
        {
            FacingLeft = true;
            //Debug.Log("left");
        }
        else { FacingLeft = false; }

        if (input.x >= 0.001f)
        {
            FacingRight = true;
            //Debug.Log("right");
        }
        else { FacingRight = false; }

    }
}
