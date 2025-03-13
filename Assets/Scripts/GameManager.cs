using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ScoreController scoreController;
    public int score;

    void Awake()
    {
        // singleton pattern
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // The DontDestroyOnLoad  will make sure the game manager stays active between scene loading.
        } else 
        {
            Destroy(gameObject);
        }
    }

    public void IncrementScore()
    {
        Debug.Log("Score is not being incremented in Game Manager. The score is: " + score);

        if(scoreController != null)
        {
            score += 50;
            scoreController.UpdateScore();
            Debug.Log("Score is being incremented in Game Manager. The score is: " + score);
        }
    }

    // Update is called once per frame
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
