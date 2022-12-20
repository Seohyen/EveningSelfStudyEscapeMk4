using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCh : MonoBehaviour
{
    [SerializeField]
    private string Sname;
    private void Update()
    {
        Debug.Log("d");
        SceneM.instance.ChangeScene(Sname);

        
    }
}
