using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private SpriteRenderer myRenderer;
    private Animator myAnimator;
    private bool grounded = false;
    private bool canMove = true;
    private bool facingRight = true;
    private float groundCheckRadius = 0.2f;
    private float horizontalDirection = 0.0f;
    private bool jumpPressed = false;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpPower;
    public float maxSpeed;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("canMove", canMove);
    }

    void Update()
    {
        ReadInput();
        CheckGrounded();

        if (canMove)
        {
            if (grounded && jumpPressed)
            {
                jump();
            }

            Move();  
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX;
    }

    private void jump()
    {
        myAnimator.SetBool("isGrounded", false);
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        myRigidbody.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
        grounded = false;
    }

    private void Move()
    {
        TurnToDirection();
        myRigidbody.velocity = new Vector2(horizontalDirection * maxSpeed, myRigidbody.velocity.y);
        myAnimator.SetFloat("MoveSpeed", Mathf.Abs(horizontalDirection * maxSpeed));
    }

    private void CheckGrounded()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnimator.SetBool("isGrounded", grounded);
    }

    private void TurnToDirection()
    {
        if (horizontalDirection > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalDirection < 0 && facingRight)
        {
            Flip();
        }
    }

    private void ReadInput()
    {
        horizontalDirection = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Jump") > 0)
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

    }

    public void toogleCanMove()
    {
        canMove = !canMove;
        myAnimator.SetBool("canMove", canMove);
    }
    
}
