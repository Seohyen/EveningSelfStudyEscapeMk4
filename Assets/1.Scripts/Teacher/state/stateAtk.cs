using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class stateAtk : State<Teacher>
{

    private Animator animator;

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        Debug.Log("State Atk Awake");
    }

    public override void OnStart()
    {
        Debug.Log("State Atk");
        animator?.SetBool("Atk", true);
    }

    public override void OnUpdate(float deltaTime) 
    {
        if (!stateMachineClass.getFlagAtk)
        {
            stateMachine.ChangeState<stateIdle>();
        }
    }

    public override void OnEnd()
    {
        Debug.Log("StateAtkEnd!");
        animator?.SetBool("Atk", false);
    }
}
