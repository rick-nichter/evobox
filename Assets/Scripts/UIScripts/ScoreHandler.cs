using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreHandler : MonoBehaviour
{
    private int score;
    public Text scoreTextObject;
    public Hashtable animalScoreValues = new Hashtable();
    void Start()
    {
        score = 0;
        scoreTextObject.text = score.ToString();
        animalScoreValues.Add("Deer", 3);
        animalScoreValues.Add("Wolf", 5);
        animalScoreValues.Add("Rabbit", 2);
        animalScoreValues.Add("Bear", 5);
        InvokeRepeating("UpdateScore", 15, 30);
    }


    public void changeScore(int deltaScore)
    {
      score += deltaScore;
      
      //don't allow negative score after score decrements on animal death
      if (score < 0)
      {
          score = 0;
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
