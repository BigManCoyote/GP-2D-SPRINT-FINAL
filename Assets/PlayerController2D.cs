using TMPro.Examples;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController2D : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float moveSpeed = 5;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public float bounceForce = 10f;
    private PlayerRespawn PlayerSpawn;


    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    private PlayerHealth playerHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        PlayerSpawn = GetComponent<PlayerRespawn>();

    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimations();

        // ⛔ Only shoot if you're NOT clicking on a UI element
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Shoot();
        }

        if (transform.position.y < -24f)
        {
            PlayerSpawn.Respawn();
        }
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Optional: Flip player sprite
        if (moveInput != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = moveInput > 0 ? 1 : -1;
            transform.localScale = scale;
        }

        // Optional: Update animation parameters
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
            animator.SetBool("isJumping", !isGrounded);
            animator.SetBool("isFalling", rb.linearVelocity.y < -0.1f);
        }
    }

    void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    void Shoot()
    {
        if (playerBulletPrefab == null || firePoint == null) return;

        GameObject bullet = Instantiate(playerBulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Determine shooting direction based on player's facing direction
            float direction = transform.localScale.x > 0 ? 1f : -1f;
            rb.linearVelocity = new Vector2(direction * bulletSpeed, 0f);
        }
    }


    void UpdateAnimations()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
            animator.SetBool("isJumping", !isGrounded);
            animator.SetBool("isFalling", rb.linearVelocity.y < -0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Check if we landed on top of the enemy
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y > 0.5f)
                {
                    Destroy(collision.gameObject);
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
                    return;
                }
            }

            // Hit from the side → take damage
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }

        if (collision.gameObject.CompareTag("HammerEnemy"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
