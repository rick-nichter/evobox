using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowBiomeUnlockHandler : MonoBehaviour
{
    public GameObject info;
    public GameObject Unlock;
    public GameObject snowBiomeArrow;
    public GameObject mainBiomeArrow;
    public Transform mainCameraPos;
    public Transform snowCameraPos; 
    public GameObject snowBiomeDividers;
    
    private bool snowUnlocked = false; 

    // Update is called once per frame
    void Update()
    {
        if (!snowUnlocked)
        {
            if (GameObject.FindGameObjectsWithTag("Wolf").Length >= 10
                && GameObject.FindGameObjectsWithTag("Deer").Length >= 10)
            {
                info.SetActive(false);
                Unlock.SetActive(true);
            }
            else
            {
                info.SetActive(true);
                Unlock.SetActive(false);
            }
        }
    }

    public void onUnlockClick()
    {
        snowUnlocked = true; 
        snowBiomeDividers.SetActive(false);
        Unlock.SetActive(false);
        snowBiomeArrow.SetActive(true);
    }

    public void onSnowBiomeArrowClick()
    {
        snowBiomeArrow.SetActive(false);
        mainBiomeArrow.SetActive(true);
        // TODO make this lerp nicely
        Camera.main.transform.position = snowCameraPos.position;
        Camera.main.transform.rotation = snowCameraPos.rotation; 
    }

    public void onMainBiomeArrowClick()
    {
        snowBiomeArrow.SetActive(true);
        mainBiomeArrow.SetActive(false);
        Camera.main.transform.position = mainCameraPos.position;
        Camera.main.transform.rotation = mainCameraPos.rotation;     
    }
}
