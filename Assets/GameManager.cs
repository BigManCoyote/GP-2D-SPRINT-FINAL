using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverPanel; // assign in Inspector
    private bool isGameOver = false;

    public GameObject gameWinPanel; // assign in Inspector
    private bool isGameWin = false;

    private int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        Time.timeScale = 1f; // Reset timescale on scene load
        Instance = this;     // Always use the current instance
    }



    public void AddScore(int amount)
    {
        score += amount;
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
    public void RestartLevel()
    {
        Debug.Log("🔁 GameManager.RestartLevel was triggered");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TriggerGameWin()
    {
        if (isGameWin) return;
        isGameWin= true;
        gameWinPanel.SetActive(true);
        Time.timeScale = 0f;

    }




    public int GetScore()
    {
        return score;
    }
    public void TriggerGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }



}
