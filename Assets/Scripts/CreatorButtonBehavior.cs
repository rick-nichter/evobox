using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatorButtonBehavior : MonoBehaviour
{
    public Button button;
    public Text nameText;
    public Image iconImage;

    private CreatorItem item;
    private CreatorContentBehavior creatorContent;

    void Start()
    {
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
        Debug.Log("Button Clicked");
    }

    
}
