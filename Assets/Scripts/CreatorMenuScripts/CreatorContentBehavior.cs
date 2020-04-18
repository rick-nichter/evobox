using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CreatorItem
{
    public string name;
    public Sprite icon;
    public int cost; 
    public GameObject prefab;

    public CreatorItem(string name, Sprite icon, int cost, GameObject prefab)
    {
        this.name = name;
        this.icon = icon;
        this.cost = cost; 
        this.prefab = prefab;
    }
}
public class CreatorContentBehavior : MonoBehaviour
{
    // The list of items to be displayed in this content pane
    public List<CreatorItem> itemList;
    // The transform of the content panel this script belongs to
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
