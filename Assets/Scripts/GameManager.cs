using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Canvas statsCanvas;
    public Canvas pauseMenuCanvas;

    // score
    public ScoreController scoreController;
    public int score;

    // time
    public TimerController timerController;
    public float secondsCount;
    public int minuteCount;
    public Camera playerCamera;
    public Cinemachine.CinemachineFreeLook freeLookCamera;
    private Transform playerTransform; 

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  

            if (statsCanvas != null)
            {
                DontDestroyOnLoad(statsCanvas.gameObject);  
            }
            if (pauseMenuCanvas != null)
            {
                DontDestroyOnLoad(pauseMenuCanvas.gameObject);  
            }
            if (playerCamera != null)
            {
                DontDestroyOnLoad(playerCamera.gameObject); // Make the Camera persist across scenes
            }
             if (freeLookCamera != null)
            {
                // You could apply DontDestroyOnLoad() to this camera as well if you want it to persist
                DontDestroyOnLoad(freeLookCamera.gameObject);
            }
            else
            {
                //Debug.LogError("Canvas is null.");
            }
        }
        else
        {
            Destroy(gameObject); 
        }
    }

        void Start()
    {
        // Optionally, reassign the target after loading the new scene
        if (freeLookCamera != null && playerTransform != null)
        {
            // Reassign the Follow and LookAt targets of the FreeLook Camera
            freeLookCamera.Follow = playerTransform;
            freeLookCamera.LookAt = playerTransform;
        }
    }

    void Update()
    {
        IncrementTimer(); // increment timer every frame
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
            Debug.Log("Score is being incremented in Game Manager. The score is: " + score);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
