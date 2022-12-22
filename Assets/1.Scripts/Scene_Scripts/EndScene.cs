using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("School_Map");
    }
}
