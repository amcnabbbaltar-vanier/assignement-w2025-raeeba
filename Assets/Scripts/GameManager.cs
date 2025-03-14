using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ScoreController scoreController;
    public int score;

    // time
    public TimerController timerController;
    //public int time;
    // public Text timerText;
    public float secondsCount;
    public int minuteCount;

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

    void Update()
    {
        IncrementTimer();
    } 

    public void IncrementTimer()
    {
        if(timerController != null)
        {
            secondsCount += Time.deltaTime;
            if (secondsCount >= 60)
            {
                minuteCount++;
                secondsCount  = 0;
            }
            timerController.UpdateTimer();
            //Debug.Log("Score is being incremented in Game Manager. The score is: " + score);
        }
    }

    public void IncrementScore()
    {

        if(scoreController != null)
        {
            score += 50;
            scoreController.UpdateScore();
            //Debug.Log("Score is being incremented in Game Manager. The score is: " + score);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
