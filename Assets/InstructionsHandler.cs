using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsHandler : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject helpButton;

    public void onHelpButtonClick()
    {
        Time.timeScale = 0; 
        instructionsPanel.SetActive(true);
        helpButton.SetActive(false);
    }

    public void onCloseClick()
    {
        Time.timeScale = 1; 
        instructionsPanel.SetActive(false);
        helpButton.SetActive(true);
    }
}
