using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    
    [SerializeField] GameObject victoryPanel; 
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI victoryText;
    [SerializeField] float timeToWin = 10f; 

    bool gameWon = false;
    float remainingTime;

    void Awake()
    {
        remainingTime = timeToWin;
        victoryPanel.SetActive(false); 
        UpdateCountdownUI();
    }
    
    void Update()
    {
        if (gameWon)
        {
            HandleVictoryInput();
            return;
        }

        remainingTime -= Time.deltaTime;
        UpdateCountdownUI();

        if (remainingTime <= 0)
        {
            TriggerVictory();
        }
    }

    void UpdateCountdownUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        countdownText.text = $"{minutes:00}:{seconds:00}"; 
    }

    void TriggerVictory()
    {
        gameWon = true;

        victoryPanel.SetActive(true);
        victoryText.text = "You Won !\n\nRetry (R) or Quit (Q) ?";

        Time.timeScale = 0; 
    }

    void HandleVictoryInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
