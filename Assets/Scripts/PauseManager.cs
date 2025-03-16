using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    private bool isPaused = false;
    public static PauseManager Instance;
    public static CharacterHealth characterHealth;


    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // show Pause Menu UI
        pauseMenuPanel.SetActive(true);
        // freeze game time
        Time.timeScale = 0f;
        isPaused = true;
        // if (pauseMenuPanel != null)
        // {
        //     pauseMenuPanel.SetActive(true); // Show the pause menu
        //     Time.timeScale = 0f; // Freeze the game time
        //     isPaused = true;
        // }
        // else
        // {
        //     Debug.LogError("PauseMenuPanel is not assigned or has been destroyed!");
        // }
    }

    public void ResumeGame()
    {
        // hide Pause Menu UI
        pauseMenuPanel.SetActive(false);
        // unfreeze game time
        Time.timeScale = 1f;
        isPaused = false;
        // if (pauseMenuPanel != null)
        // {
        //     pauseMenuPanel.SetActive(false); // Hide the pause menu
        //     Time.timeScale = 1f; // Unfreeze the game time
        //     isPaused = false;
        // }
        // else
        // {
        //     Debug.LogError("PauseMenuPanel is not assigned or has been destroyed!");
        // }
    }

    public void RestartLevel()
    {
        GameManager.Instance.ResetStats();
        characterHealth.Instance.ResetHealth();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }


    public void QuitGame()
    {
        Application.Quit();
        //SceneManager.LoadScene("MainMenu");
    }
}
