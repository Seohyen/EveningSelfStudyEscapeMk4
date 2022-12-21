using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    [SerializeField]
    private GameObject start_Button;
    [SerializeField]
    private GameObject tutorial_Button;
    [SerializeField]
    private GameObject tutorial_Penel;
    [SerializeField]
    private GameObject exit_Button;

    public void OnClickTutorialButton()
    {
        tutorial_Penel.SetActive(true);
        exit_Button.SetActive(true);
    }

    public void OnClickExitButton()
    {
        tutorial_Penel.SetActive(false);
        exit_Button.SetActive(false);
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("CinemachineScene");
    }
}
