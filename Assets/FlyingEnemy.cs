using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [Header("Patrol Settings")]
    public float speed = 2f;
    public float patrolDistance = 3f;

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    public float bulletSpeed = 5f;

    private Vector2 startPos;
    private bool movingRight = true;
    private float shootTimer;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        HandlePatrol();
        HandleShooting();
    }

    void HandlePatrol()
    {
        float direction = movingRight ? 1f : -1f;
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        if (movingRight && transform.position.x >= startPos.x + patrolDistance)
        {
            movingRight = false;
            Flip();
        }
        else if (!movingRight && transform.position.x <= startPos.x - patrolDistance)
        {
            movingRight = true;
            Flip();
        }
    }

    void HandleShooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && rb != null)
        {
            Vector2 direction = (player.transform.position - firePoint.position).normalized;
            rb.linearVelocity = direction * bulletSpeed;
        }

        // Ignore collision between bullet and shooter
        Collider2D bulletCollider = bullet.GetComponent<Collider2D>();
        Collider2D enemyCollider = GetComponent<Collider2D>();

        if (bulletCollider != null && enemyCollider != null)
        {
            Physics2D.IgnoreCollision(bulletCollider, enemyCollider);
        }
    }



    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
