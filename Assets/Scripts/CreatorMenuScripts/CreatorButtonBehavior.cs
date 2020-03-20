using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatorButtonBehavior : MonoBehaviour
{
    public Button button;
    public Text nameText;
    public Image iconImage;
    public GameManagerScript gameManager;

    private CreatorItem item;
    private CreatorContentBehavior creatorContent;

    void Start()
    {
        if (!gameManager)
        {
            // Get the game manager (there should only be one present at any given time)
            gameManager = FindObjectOfType<GameManagerScript>();
        }
        button.onClick.AddListener(HandleClick);
    }

    public void Setup(CreatorItem currentItem, CreatorContentBehavior currentContent)
    {
        item = currentItem;
        nameText.text = item.name;
        iconImage.sprite = item.icon;
        creatorContent = currentContent;
    }

    public void HandleClick()
    {
        // whatever clicking this button should do
        gameManager.SetState(GameState.Place, item.prefab);
    }

    // User enters Placement Mode, where a transparent species object will be displayed where they move their mouse
    // until they click, thus placing the species at the desired location
    private void PlaceSpecies()
    {

    }

    
}
