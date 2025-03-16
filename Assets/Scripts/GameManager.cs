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

    // // health
    // public int maxHealth = 3;
    // private int currentHealth;
    // public Slider healthBar;

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

            if (statsCanvas != null) // score and timer 
            {
                DontDestroyOnLoad(statsCanvas.gameObject);  
            } 
            else
            {
                Destroy(statsCanvas.gameObject); 
            }
            if (pauseMenuCanvas != null) // pause menu
            {
                DontDestroyOnLoad(pauseMenuCanvas.gameObject);  
            }
            else
            {
                Destroy(pauseMenuCanvas.gameObject); 
            }
            if (playerCamera != null) // player camera
            {
                DontDestroyOnLoad(playerCamera.gameObject); 
            }
            else
            {
                Destroy(playerCamera.gameObject); 
            }
             if (freeLookCamera != null) // free look camera
            {
                DontDestroyOnLoad(freeLookCamera.gameObject);
            }
            else
            {
                Destroy(freeLookCamera.gameObject); 
            }
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    //! TO SEE
    void Start()
    {
        // assign  the player subject to the free look camera
        if (freeLookCamera != null && playerTransform != null)
        {
            freeLookCamera.Follow = playerTransform;
            freeLookCamera.LookAt = playerTransform;
        }

        // currentHealth = maxHealth;
        // healthBar.maxValue = maxHealth;
        // healthBar.value = currentHealth;
    }

    // reset score and time
    public void ResetStats()
    {
        score = 0;
        scoreController.UpdateScore(0); // update score ui
        minuteCount = 0;
        secondsCount = 0;
        // currentHealth = maxHealth;
    }

    void Update()
    {
        IncrementTimer(); // increment timer every frame
    } 

    // increment time
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

    // increment score
    public void IncrementScore()
    {

        if(scoreController != null)
        {
            score += 50;
            scoreController.UpdateScore(score);
            Debug.Log("Score is being incremented in Game Manager. The score is: " + score);
        }
    }

    // public void TakeDamage(int damage)
    // {
    //     currentHealth -= damage;
    //     healthBar.value = currentHealth;
    //     if(currentHealth <= 0)
    //     {
    //         Die();
    //     }
    // }

    // public void Die()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    // }

    // load the next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
