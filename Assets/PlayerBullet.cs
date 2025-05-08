using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float lifetime = 5f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Replace with health logic if needed
            GameManager.Instance.AddScore(1); // Increase score
            Destroy(gameObject);
        }
    }
}
