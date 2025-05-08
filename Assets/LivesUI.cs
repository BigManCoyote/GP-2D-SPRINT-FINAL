using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public PlayerRespawn playerRespawn;
    public TextMeshProUGUI livesText;

    void Update()
    {
        if (playerRespawn != null && livesText != null)
        {
            livesText.text = "Lives: " + playerRespawn.GetLives();
        }
    }
}
