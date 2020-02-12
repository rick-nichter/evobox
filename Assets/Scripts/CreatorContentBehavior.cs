using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CreatorItem
{
    public string name;
    public Sprite icon;
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

    private void AddButtons()
    {
        foreach (CreatorItem item in itemList)
        {
            GameObject newButton = objectPool.GetObject();
            newButton.transform.SetParent(contentPanel, false);

            CreatorButtonBehavior creatorButton = newButton.GetComponent<CreatorButtonBehavior>();
            creatorButton.Setup(item, this);
        }
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject removing = transform.GetChild(0).gameObject;
            objectPool.ReturnToInactivePool(removing);
        }
    }

    private void AddItem(CreatorItem item)
    {
        itemList.Add(item);
    }

    private void RemoveItem(CreatorItem item)
    {
        itemList.Remove(item);
    }
}
