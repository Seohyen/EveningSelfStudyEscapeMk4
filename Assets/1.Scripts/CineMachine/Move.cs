using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float spd;

    Rigidbody rb;
    Animator anim;

    bool isWalk = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

        Invoke("MoveT", 8);
    }

    private void MoveT()
    {
        rb.AddForce(Vector3.back * spd);

       
    }

}
