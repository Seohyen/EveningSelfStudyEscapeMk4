using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Teacher")
        {
            animator.SetBool("IsOpen", true);
            SoundManager.instance.DoorSoundPlay();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Teacher")
        {
            animator.SetBool("IsOpen", false);
        }
    }
}
