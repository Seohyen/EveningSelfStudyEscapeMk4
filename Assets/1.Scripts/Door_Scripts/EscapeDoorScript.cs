using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoorScript : MonoBehaviour
{
    Animator animator;
    private RandomKey randomKey;

    private void Start()
    {
        animator = GetComponent<Animator>();
        randomKey = GetComponent<RandomKey>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (randomKey.isKey == true)
        {
            if (other.tag == "Player")
            {
                Debug.Log("Open!");
                animator.SetBool("IsOpen", true);
                SoundManager.instance.DoorSoundPlay();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit!");
        if (other.tag == "Player")
        {
            animator.SetBool("IsOpen", false);
            SoundManager.instance.DoorSoundPlay();
        }
    }
}
