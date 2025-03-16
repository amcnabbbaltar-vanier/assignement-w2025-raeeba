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
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(true);
        if (GameManager.Instance)
        {
            finalScoreText.text = "Score: " + GameManager.Instance.score.ToString();
            finalTimerText.text = "M: " + GameManager.Instance.minuteCount.ToString("00") + " S: " + Mathf.FloorToInt(GameManager.Instance.secondsCount).ToString("00");
        }
    }

    public void RestartGame()
    {
        gameOverPanel.SetActive(false);
        GameManager.Instance.ResetStats();
        SceneManager.LoadScene("SampleScene"); 
    }
}
