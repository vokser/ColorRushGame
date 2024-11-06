using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    public static MenuManager instance;

    private void Awake()
    {
        if (instance == null)
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
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        _bestScoreText.text = "Best Score: " + bestScore;
        _menuPanel.SetActive(true);
        _settingsPanel.SetActive(false);
    }

    private void ToPlay()
    {
        SceneManager.LoadScene(1);
    }
   
    private void ToSettings()
    {
        _menuPanel.SetActive(false);
        _settingsPanel.SetActive(true);
    }

    private void ToMenu()
    {
        _settingsPanel.SetActive(false);
        _menuPanel.SetActive(true);
    }
}
