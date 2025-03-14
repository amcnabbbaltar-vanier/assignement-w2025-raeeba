using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject timerPanel;
    public TimerController Instance;

    // Start is called before the first frame update
    void Start()
    {   
        timerPanel.SetActive(true);
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            if (GameManager.Instance != null)
            {
                timerText.text = "M: " + GameManager.Instance.minuteCount.ToString("00") + " S: " + Mathf.FloorToInt(GameManager.Instance.secondsCount).ToString("00");
            }
            else
            {
                //Debug.LogError("GameManager.Instance is null. Make sure the GameManager is properly initialized.");
            }
        } 
        else 
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void UpdateTimer()
    {
        if (timerText != null)
        {
            timerText.text = "M: " + GameManager.Instance.minuteCount.ToString("00") + " S: " + Mathf.FloorToInt(GameManager.Instance.secondsCount).ToString("00");
            //Debug.Log("Time was incremented in Timer Controller: " + timerText);
        }
        else
        {
            //Debug.LogWarning("TimerText is not assigned in TimerController.");
        }
    }

    // public void RestartGame()
    // {
    //     SceneManager.LoadScene(0);
    // }
}
