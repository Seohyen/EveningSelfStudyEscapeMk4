using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    #region Singleton
    private static SceneM _instance = null;

    public static SceneM instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SceneM>();
                if (_instance == null)
                {
                    _instance = new GameObject("SceneM").AddComponent<SceneM>();
                }
            }
            return _instance;
        }
    }
    #endregion

    [SerializeField]
    private string scenename;
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
