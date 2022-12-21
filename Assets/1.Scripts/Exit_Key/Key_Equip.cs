using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Equip : MonoBehaviour
{
    public bool isKey;

    private bool isCheck;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Key Equip");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player!");
            isCheck = true;
        }
    }

    private void Update()
    {
        if (isCheck == true)
        {
            Debug.Log("isCheck!");
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Press F");
                Destroy(gameObject);
                isKey = true;
            }
        }
    }
}
