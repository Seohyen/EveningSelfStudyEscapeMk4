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

    public void Clear1()
    {
        if (inventoryObj.invenSlots != null)
        {
            inventoryObj.invenSlots[0].itemCnt -= 1;
            ItemObj newItemObj = Player.Instace.nowItem;
            Item newItem = new Item(newItemObj);

            inventoryObj.UseItem(newItem, 1);
            ItemPickup.instance.Debuglog();
            if (inventoryObj.invenSlots[0].itemCnt <= 0)
            {
                inventoryObj.invenSlots[0].slotUI.transform.GetChild(0).GetComponent<Image>().sprite = null;
            }
        }
        if (inventoryObj.invenSlots[0].itemCnt == 0)
        {
            return;
        }
    }

    public void Clear2()
    {
        if (inventoryObj.invenSlots != null)
        {
            inventoryObj.invenSlots[1].itemCnt -= 1;
            ItemObj newItemObj = Player.Instace.nowItem;
            Item newItem = new Item(newItemObj);

            inventoryObj.UseItem(newItem, 1);
            if(inventoryObj.invenSlots[1].itemCnt <= 0)
            {
                inventoryObj.invenSlots[1].slotUI.transform.GetChild(1).GetComponent<Image>().sprite = null;
            }
            if(inventoryObj.invenSlots[1].itemCnt == 0)
            {

                return;
            }
        }

    }


}

    




