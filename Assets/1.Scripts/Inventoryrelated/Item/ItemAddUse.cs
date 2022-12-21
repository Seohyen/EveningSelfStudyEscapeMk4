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

    public bool isItem1 = false;
    public bool isItem2 = false;
    public bool isItem3 = false;
    public bool isItem4 = false;

    public void Clear(int value)
    {
        if (inventoryObj.invenSlots != null)
        {
            inventoryObj.invenSlots[value].itemCnt -= 1;

            Item newItem = inventoryObj.invenSlots[value].item;

            
            if (inventoryObj.invenSlots[value].item.item_id == 0)
            {
                isItem1 = true;
            }
            else if (inventoryObj.invenSlots[value].item.item_id == 1)
            {
                Debug.LogWarning("1");
                isItem2 = true;
            }
            else if (inventoryObj.invenSlots[value].item.item_id == 2)
            {
                isItem3 = true;
            }
            else if (inventoryObj.invenSlots[value].item.item_id == 3)
            {
                isItem4 = true;
            }

            inventoryObj.UseItem(newItem, 1);
           
          

           
            
            if (inventoryObj.invenSlots[value].itemCnt <= 0)
            {
                inventoryObj.invenSlots[value].slotUI.transform.GetChild(value).GetComponent<Image>().sprite = null;
            }
        }

    }



}






