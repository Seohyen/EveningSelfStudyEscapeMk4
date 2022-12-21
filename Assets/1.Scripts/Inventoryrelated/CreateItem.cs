using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ItemObj1;
    [SerializeField]
    private GameObject[] ItemObj2;
    [SerializeField]
    private GameObject[] ItemObj3;
    [SerializeField]
    private GameObject[] ItemObj4;


    private void Start()
    {
        CreateItem1();
        CreateItem2();
        CreateItem3();
        CreateItem4();
    }

    private void CreateItem1()
    {
         int selection = Random.Range(0, ItemObj1.Length);
        GameObject selectedPrefab = ItemObj1[selection];

        for(int i =0; i< Random.Range(1, 3); i++)
        {
        selectedPrefab.SetActive(true);
        }
    }
    private void CreateItem2()
    {
        int selection = Random.Range(0, ItemObj2.Length);
        GameObject selectedPrefab = ItemObj2[selection];

        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            selectedPrefab.SetActive(true);
        }
    }

    private void CreateItem3()
    {
        int selection = Random.Range(0, ItemObj3.Length);
        GameObject selectedPrefab = ItemObj3[selection];

        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            selectedPrefab.SetActive(true);
        }
    }

    private void CreateItem4()
    {
        int selection = Random.Range(0, ItemObj4.Length);
        GameObject selectedPrefab = ItemObj1[selection];

            selectedPrefab.SetActive(true);
    }
}
