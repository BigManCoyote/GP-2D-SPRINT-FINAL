using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TextMeshProUGUI heartText;

    void Update()
    {
        if (playerHealth != null && heartText != null)
        {
            heartText.text = "x " + playerHealth.GetHealth();
           
        }
    }

}
