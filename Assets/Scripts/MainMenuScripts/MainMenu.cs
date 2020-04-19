using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public TextMeshProUGUI highScoreText; 
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GetHighScore()
    {
        highScoreText.text = "High Score -> " + PlayerPrefs.GetInt("HighScore", 0).ToString(); 
    }

}
