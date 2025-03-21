using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalTimerText;
    public TextMeshProUGUI finalScoreText;
   
    void Start()
    {
        gameOverPanel.SetActive(true); // make gameOver panel visible
        if (GameManager.Instance) 
        {
            finalScoreText.text = "Final Score: " + GameManager.Instance.score.ToString();
            finalTimerText.text = "Final Time: " + GameManager.Instance.minuteCount.ToString("00") + "m" + Mathf.FloorToInt(GameManager.Instance.secondsCount).ToString("00") + "s";
        }
    }

    // restart game
    public void RestartGame()
    {
        gameOverPanel.SetActive(false);
        GameManager.Instance.ResetStats(); // reset score and time
        SceneManager.LoadScene("SampleScene"); // load first level
    }
}
