using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("School_Map");
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
