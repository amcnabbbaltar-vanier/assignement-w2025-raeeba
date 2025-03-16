using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject scorePanel;
    public ScoreController Instance;

    // Start is called before the first frame update
    void Start()
    {
        scorePanel.SetActive(true);
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            
            if (GameManager.Instance != null)
            {
                scoreText.text = "Score: " + GameManager.Instance.score;
            }
            else
            {
                Debug.LogError("GameManager.Instance is null.");
            }
        } 
        else 
        {
            Destroy(gameObject);
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

