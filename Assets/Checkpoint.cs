using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                respawn.ReachCheckpoint(checkpointIndex);
            }
        }
        
    }
}
