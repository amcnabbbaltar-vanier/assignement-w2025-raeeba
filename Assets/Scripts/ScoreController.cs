using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject scorePanel;

    // Start is called before the first frame update
    void Start()
    {
        scorePanel.SetActive(true);
        if (GameManager.Instance != null)
        {
            // Initialize the score text when the scene starts
            scoreText.text = "Score: " + GameManager.Instance.score.ToString();
        }
        else
        {
            Debug.LogError("GameManager.Instance is null. Make sure the GameManager is properly initialized.");
        }
    }

    public void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.score.ToString();
            Debug.Log("Score was incremented in Score Controller: " + scoreText);
        }
        else
        {
            Debug.LogWarning("ScoreText is not assigned in ScoreController.");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

