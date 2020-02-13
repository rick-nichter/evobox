using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CreatorItem
{
    public string name;
    public Sprite icon;

    public CreatorItem(string name, Sprite icon)
    {
        this.name = name;
        this.icon = icon; 
    }
}
public class CreatorContentBehavior : MonoBehaviour
{
    public List<CreatorItem> itemList;
    public Transform contentPanel;
    public ObjectPool objectPool;

    void Start()
    {
        // RemoveButtons();
        AddButtons();
    }

    public void AddButtons()
    {
        foreach (CreatorItem item in itemList)
        {
            DrawButton(item);
        }
    }

    private void DrawButton(CreatorItem item)
    {
        
        GameObject newButton = objectPool.GetObject();
        newButton.transform.SetParent(contentPanel, false);

        CreatorButtonBehavior creatorButton = newButton.GetComponent<CreatorButtonBehavior>();
        creatorButton.Setup(item, this);
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject removing = transform.GetChild(0).gameObject;
            objectPool.ReturnToInactivePool(removing);
        }
    }

    public void AddItem(CreatorItem item)
    {
        itemList.Add(item);
        DrawButton(item);

    }

    public void RemoveItem(CreatorItem item)
    {
        itemList.Remove(item);
    }
}
