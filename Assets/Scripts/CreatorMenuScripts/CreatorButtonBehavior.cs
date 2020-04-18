using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatorButtonBehavior : MonoBehaviour
{
    public Button button;
    public Text nameText;
    public Image iconImage;
    public Text costText; 
    public GameManagerScript gameManager;

    private CreatorItem item;
    private CreatorContentBehavior creatorContent;

    private int cost;

    private CoinHandler coinHandler;

    private void Awake()
    {
        coinHandler = FindObjectOfType<CoinHandler>(); 
    }

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
        costText.text = item.cost.ToString();
        iconImage.preserveAspect = true;
        creatorContent = currentContent;
        cost = item.cost; 
    }

    public void HandleClick()
    {
        // whatever clicking this button should do
        if (cost <= coinHandler.getCoins())
        {
            gameManager.SetState(GameState.Place, item.prefab, cost);
        }
        else
        {
            coinHandler.showTooExpensive(); 
        }
    }
    
}
