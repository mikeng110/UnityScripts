using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D myRigidbody;
    private SpriteRenderer myRenderer;
    private Animator myAnimator;
    private bool grounded = false;
    private bool canMove = true;
    private bool facingRight = true;
    private float groundCheckRadius = 0.2f;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("canMove", canMove);
    }

    void FixedUpdate()
    {
        CheckGrounded();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX;
    }

    public  void Jump(float jumpPower)
    {
        if (grounded && canMove)
        {
            myAnimator.SetBool("isGrounded", false);
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            myRigidbody.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            grounded = false;
        }
        
    }

    public void HorizontalMove(float horizontalVelcoity)
    {
        if(canMove)
        {
            TurnToDirection(horizontalVelcoity);
            myRigidbody.velocity = new Vector2(horizontalVelcoity, myRigidbody.velocity.y);
            myAnimator.SetFloat("MoveSpeed", Mathf.Abs(horizontalVelcoity));
        }
        
    }

    private void CheckGrounded()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnimator.SetBool("isGrounded", grounded);
    }

    private void TurnToDirection(float horizontalVelcoity)
    {
        if (horizontalVelcoity > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalVelcoity < 0 && facingRight)
        {
            Flip();
        }
    }

    public void ToogleCanMove()
    {
        canMove = !canMove;
        myAnimator.SetBool("canMove", canMove);
    }
    
}
