using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    
    private int score;
    
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        score = 0;
    }


    private void RestartGame()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    private void Continue()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    private void ToMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void ScoreCounter(int amount)
    {
        score += amount;
        scoreText.text = " " + score;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Final Score: " + score;
        scoreText.gameObject.SetActive(false);

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if(score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
        }
    }

}
