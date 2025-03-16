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

    void Start()
    {   
        timerPanel.SetActive(true); // show timer panel

        // Singleton 
        if (Instance == null)
        {
            Instance = this;  
            DontDestroyOnLoad(gameObject);  
            
            if (GameManager.Instance != null)
            {
                timerText.text = GameManager.Instance.minuteCount.ToString("00") + "m"  + Mathf.FloorToInt(GameManager.Instance.secondsCount).ToString("00") + "s";
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


    // update timer based on game manager
    public void UpdateTimer()
    {
        if (timerText != null)
        {
            timerText.text = GameManager.Instance.minuteCount.ToString("00") + "m" + Mathf.FloorToInt(GameManager.Instance.secondsCount).ToString("00") + "s";
            //Debug.Log("Time was incremented in Timer Controller: " + timerText);
        }
        else
        {
            Debug.LogWarning("TimerText is not assigned in TimerController.");
        }
    }
}
