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

    void Start()
    {
        scorePanel.SetActive(true); // show score panel
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

    // update score based on game manager
    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.score.ToString();
            //Debug.Log("Score was incremented in Score Controller: " + scoreText);
        }
        else
        {
            Debug.LogWarning("ScoreText is not assigned in ScoreController.");
        }
    }
}

