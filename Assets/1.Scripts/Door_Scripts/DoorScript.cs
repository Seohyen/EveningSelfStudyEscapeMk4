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
            Debug.Log("Open!");
            animator.SetBool("IsOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit!");
        if (other.tag == "Player" || other.tag == "Teacher")
        {
            animator.SetBool("IsOpen", false);
        }
    }
}
