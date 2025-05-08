using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform[] spawnPoints; // Assign all spawn points in order (0 = starting point)
    public int maxLives = 20;

    private int currentLives;
    private int lastCheckpointIndex = 0; // Start at first spawn

    private Rigidbody2D rb;

    void Start()
    {
        currentLives = maxLives;
        rb = GetComponent<Rigidbody2D>();
        Respawn(); // Start at spawn point 0
    }
    
    public void ReachCheckpoint(int index)
    {
        if (index == 3)
        {
            GameManager.Instance.TriggerGameWin();
            Debug.Log("You Win!");
        }
        if (index > lastCheckpointIndex)
        {
            lastCheckpointIndex = index;
            Debug.Log("Reached checkpoint: " + index);
        }
        
    }

    public void Respawn()
    {
        transform.position = spawnPoints[lastCheckpointIndex].position;
        currentLives--;
        if (currentLives < 1)
        {
            GameManager.Instance.TriggerGameOver();
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = Vector2.zero;
    }

    public int GetLives() => currentLives;
}
