using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoorScript : MonoBehaviour
{
    Animator animator;
    private Key_Equip key_equip;

    private void Start()
    {
        animator = GetComponent<Animator>();
        key_equip = FindObjectOfType<Key_Equip>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (key_equip.isKey == true)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                animator.SetBool("IsOpen", true);
                SoundManager.instance.DoorSoundPlay();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("IsOpen", false);
            SoundManager.instance.DoorSoundPlay();
        }
    }
}
