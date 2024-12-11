using UnityEngine;

public class Skeletmovement : MonoBehaviour
{
    [SerializeField] private Transform _bulletPivot;
    public float runSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;

    private Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Move();
        Jump();
        UpdateAnimation();
    }

    public void Diactivate()
    {

        rb.velocity = Vector2.zero;
        this.enabled = false;

    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(horizontalInput * runSpeed, rb.velocity.y);
        rb.velocity = moveVelocity;

        // Flip the character sprite based on direction
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // facing left
        }
    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void UpdateAnimation()
    {
        float speed = Mathf.Abs(rb.velocity.x); // Get the absolute speed
        animator.SetFloat("Speed", speed); // Set the "speed" parameter in Animator
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the character is grounded
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the character leaves the ground
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
//аминь