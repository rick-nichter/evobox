using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalCountUI : MonoBehaviour
{
    public int[] animalCounts;
    public string[] animalNames;
    public Text[] textObjects;

    void Update()
    {

        for (int i = 0; i < animalCounts.Length; i++)
        {
            animalCounts[i] = GameObject.FindGameObjectsWithTag(animalNames[i]).Length;
            textObjects[i].text = animalCounts[i].ToString();
        }
    }
}
