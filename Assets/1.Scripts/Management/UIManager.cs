using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private string sceneName; 


    public void OnClickMoveScene()
    {
        SceneM.instance.ChangeScene(sceneName);
    }
}
