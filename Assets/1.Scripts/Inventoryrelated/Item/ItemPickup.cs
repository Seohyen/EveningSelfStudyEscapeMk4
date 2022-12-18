using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public static ItemPickup instance;

    private void Awake()
    {
        instance = this;
    }
    public ItemObj item;
    public void Debuglog()
    {
        Debug.Log(item.name); 
    }
}
