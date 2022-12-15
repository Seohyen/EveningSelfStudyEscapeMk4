using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateIdle : State<Teacher>
{
    public bool flagRoaming = true;
    private float roamingStateMinIdleTime = 0.0f;
    private float roamingStateMaxIdleTime = 3.0f;
    private float roamingStateIdleTime = 0.0f;

    private Animator animator;
    private CharacterController characterController;

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        characterController = stateMachineClass.GetComponent<CharacterController>();
    }

    public override void OnStart()
    {
        Debug.Log("State Idle");
        animator?.SetBool("IsFind", false);
        characterController?.Move(Vector3.zero);

        if (flagRoaming)
        {
            roamingStateIdleTime = Random.Range(roamingStateMinIdleTime, roamingStateMaxIdleTime);
        }
    }

    public override void OnUpdate(float deltaTime)
    {
        if (stateMachineClass.target)
        {
            
            if (stateMachineClass.getFlagAtk)
            {
                stateMachine.ChangeState<stateAtk>();
            }
            else
            {
                stateMachine.ChangeState<stateMove>();
            }
        }
        else if (flagRoaming && stateMachine.getStateDurationTime > roamingStateIdleTime)
        {
            stateMachine.ChangeState<stateRoaming>();
        }
    }

    public override void OnEnd()
    {
    }
}