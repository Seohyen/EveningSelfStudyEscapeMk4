using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ItemType : int
{
    Default,
    Shoes
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Items/New Item")]
public class ItemObj : ScriptableObject
{
    public ItemType itemType;
    public bool getFlagStackable;

    public Sprite itemIcon;
    public GameObject objModelPrefab;

    public Item itemData = new Item();

    public List<string> boneNameLists = new List<string>();

    [TextArea(15, 20)]
    public string itemSummery;

    private void OnValidate()
    {
        boneNameLists.Clear();

    }

    public Item createItemObj()
    {
        Item new_Item = new Item(this);
        return new_Item;
    }
}