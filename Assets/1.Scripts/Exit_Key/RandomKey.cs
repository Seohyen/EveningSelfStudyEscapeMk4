using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKey : MonoBehaviour
{
    public Transform[] posRandomKey;
    public GameObject Key;
    public bool isKey;

    private void Awake()
    {
        RandomKeyProduce();
    }

    void RandomKeyProduce()
    {
        int randomKeyPos = Random.Range(0, posRandomKey.Length);

        var key = Instantiate(Key);
        key.transform.position = posRandomKey[randomKeyPos].position;

        isKey = true;
    }
}
