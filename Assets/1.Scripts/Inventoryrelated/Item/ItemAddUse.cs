using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemAddUse : MonoBehaviour
{
    #region
    public static ItemAddUse Instace = null;

    public static ItemAddUse GetInstace()
    {
        return Instace;
    }

    private void Awake()
    {
        Instace = this;
    }

    #endregion
    public InventoryObj equipObj;
    public InventoryObj inventoryObj;
    public ItemDBObj itemDBObj;
    InvenSlot invenSlot;
    public void AddNewItem()
    {
        if (itemDBObj.itemObjs.Length > 0)
        {

            ItemObj newItemObj = ItemPickup.instance.item;
            Item newItem = new Item(newItemObj);
            if (newItemObj != null)
            {
                inventoryObj.AddItem(newItem, 1);
            }
        }
    }

    public void Clear()
    {
        if (inventoryObj.invenSlots != null)
        {
            inventoryObj.invenSlots[0].itemCnt -= 1;
            ItemObj newItemObj = ItemPickup.instance.item;
            Item newItem = new Item(newItemObj);

            inventoryObj.UseItem(newItem, 1);

            if (inventoryObj.invenSlots[0].itemCnt <= 0)
            {
                inventoryObj.invenSlots[0].slotUI.transform.GetChild(0).GetComponent<Image>().sprite = null;
            }
        }
    }



}

    




