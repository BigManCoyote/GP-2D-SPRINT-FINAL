using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float patrolDistance = 1f;
    public float speed = 2f;

    private Vector2 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float moveDirection = movingRight ? 1f : -1f;
        transform.Translate(Vector2.right * moveDirection * speed * Time.deltaTime);

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

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
