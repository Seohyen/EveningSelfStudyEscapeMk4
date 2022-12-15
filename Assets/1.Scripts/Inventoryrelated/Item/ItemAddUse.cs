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
            Debug.Log(inventoryObj.invenSlots[0].itemCnt);
            invenSlot.slotUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = invenSlot.itemCnt.ToString("n0");

            if (inventoryObj.invenSlots[0].itemCnt <= 0)
            {
                Debug.Log("D");
                inventoryObj.invenSlots[0].slotUI.transform.GetChild(0).GetComponent<Image>().sprite = null;
            }
        }

    }



}

