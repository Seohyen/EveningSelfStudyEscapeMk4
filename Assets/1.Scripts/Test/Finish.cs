using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{


    public string scenename;
    void Start()
    {
    }


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            SceneM.instance.ChangeScene("TestFinish");
        }
        
    }
    
    
}
