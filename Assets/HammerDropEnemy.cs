using UnityEngine;

public class HammerDropEnemy : MonoBehaviour
{
    public float riseSpeed = 2f;
    public float waitTime = 1f;

    private Vector2 originalPosition;
    private Rigidbody2D rb;
    private bool dropping = true;
    private bool waiting = false;

    void Start()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (dropping && collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            dropping = false;
            StartCoroutine(WaitAndRise());
        }
    }

    private System.Collections.IEnumerator WaitAndRise()
    {
        waiting = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(waitTime);

        waiting = false;
    }

    void Update()
    {
        if (!dropping && !waiting)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPosition, riseSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, originalPosition) < 0.01f)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                dropping = true;
            }
        }
    }
}
