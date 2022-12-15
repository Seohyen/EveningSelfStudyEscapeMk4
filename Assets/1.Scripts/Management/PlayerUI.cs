using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{


    [SerializeField]
    private Slider staminaBar;

    [SerializeField]
    private Slider spaceBar; 


    private void Awake()
    {
        spaceBar.gameObject.SetActive(false);
    }

    private void Update()
    {
        StaminaBar();
    }

    public void StaminaBar()
    {
        staminaBar.value = Player.Instace.stamina/5;
        
    
    }

   

    
}
