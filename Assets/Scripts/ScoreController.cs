using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject scorePanel;

    // Start is called before the first frame update
    void Start()
    {
        scorePanel.SetActive(true);
        if(GameManager.Instance)
        {
            scoreText.text = "Score: " + GameManager.Instance.score.ToString();
        }
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

