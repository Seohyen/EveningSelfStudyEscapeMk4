using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{

    [SerializeField]
    private GameObject panel;
   
    void Start()
    {
        panel.SetActive(false);   
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
            Time.timeScale = 0;
            panel.SetActive(true);
       }
    }

    public void OnClickResum()
    {
        panel.SetActive(false);
        Time.timeScale = 1; 
    }
    
    public void OnClickExit()
    {
        Application.Quit();
    }
}
