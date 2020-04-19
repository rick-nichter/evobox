using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnlockAnimalsScripts;


public class ScoreHandler : MonoBehaviour
{
    private int score;
    public Text scoreTextObject;
    public Text highScoreText;
    public Hashtable animalScoreValues = new Hashtable();

    private int addXP = 0;

    private AnimalTreeHandler animalTreeHandler;

    private void Awake()
    {
        animalTreeHandler = FindObjectOfType<AnimalTreeHandler>();
    }

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        score = 0;
        scoreTextObject.text = score.ToString();
        animalScoreValues.Add("Deer", 4);
        animalScoreValues.Add("Wolf", 5);
        animalScoreValues.Add("Rabbit", 3);
        animalScoreValues.Add("Bear", 7);
        InvokeRepeating("UpdateScore", 10, 10);
    }


    public void changeScore(int deltaScore)
    {
        // For every 10 score the user earns reward 1 xp.  XP can't be lost only spent. 
        if (deltaScore > 0)
        {
            addXP += deltaScore;
            if (addXP >= 10)
            {
                animalTreeHandler.addXP();
                addXP -= 10; 
            }
        }
        
        
        score += deltaScore;
      
        //don't allow negative score after score decrements on animal death
        if (score < 0)
        {
            score = 0;
        }

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        
        scoreTextObject.text = score.ToString();
    }

    private void UpdateScore()
    {
        foreach (string name in animalScoreValues.Keys)
        {
            changeScore(GameObject.FindGameObjectsWithTag(name).Length * (int)animalScoreValues[name]);
        }
    }
}
