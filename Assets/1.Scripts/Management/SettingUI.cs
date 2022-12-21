using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{

    [SerializeField]
    private GameObject panel;

    public bool isEsc = false;
   
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

            isEsc = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void OnClickResum()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        isEsc = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Resum");
    }
    
    public void OnClickExit()
    {
        Application.Quit();
    }
}
