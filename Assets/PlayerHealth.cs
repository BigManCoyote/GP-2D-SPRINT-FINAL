using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private PlayerRespawn respawn;

    void Start()
    {
        currentHealth = maxHealth;
        respawn = GetComponent<PlayerRespawn>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            respawn.Respawn();
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
