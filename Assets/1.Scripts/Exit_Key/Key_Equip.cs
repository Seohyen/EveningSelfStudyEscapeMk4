using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Equip : MonoBehaviour
{
    public bool isKey;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Key Equip");
        if (gameObject.CompareTag("Key"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                Destroy(gameObject);
                isKey = true;
            }
        }
    }
}
