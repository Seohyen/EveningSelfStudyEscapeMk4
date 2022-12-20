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

            ItemObj newItemObj = Player.Instace.nowItem;
            Item newItem = new Item(newItemObj);
            if (newItemObj != null)
            {
                inventoryObj.AddItem(newItem, 1);
            }
        }
    }


    public void Clear(int value)
    {
        if (inventoryObj.invenSlots != null)
        {
            inventoryObj.invenSlots[value].itemCnt -= 1;

            Item newItem = inventoryObj.invenSlots[value].item;

            inventoryObj.UseItem(newItem, 1);
            ItemPickup.instance.Debuglog();
            if (inventoryObj.invenSlots[value].itemCnt <= 0)
            {
                inventoryObj.invenSlots[value].slotUI.transform.GetChild(value).GetComponent<Image>().sprite = null;
            }
        }
        if (inventoryObj.invenSlots[value].itemCnt == 0)
        {
            return;
        }
    }



}

    




