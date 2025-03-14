using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    private bool isPaused = false;
    public PauseManager Instance;


    void Start()
    {
        //scorePanel.SetActive(true);
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    // Update is called once per frame
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
    }

    public void ResumeGame()
    {
        // hide Pause Menu UI
        pauseMenuPanel.SetActive(false);
        // unfreeze game time
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        //SceneManager.LoadScene("MainMenu");
    }
}
