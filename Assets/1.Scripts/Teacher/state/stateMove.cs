using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class stateMove : State<Teacher>
{
    private Animator animator;
    private CharacterController characterController;
    private NavMeshAgent agent;

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        characterController = stateMachineClass.GetComponent<CharacterController>();
        agent = stateMachineClass.GetComponent<NavMeshAgent>();
    }

    public override void OnStart()
    {
        Debug.Log("State Move");
        agent?.SetDestination(stateMachineClass.target.position);
        animator?.SetBool("IsFind", true);
        agent.speed = 5.0f;
    }

    public override void OnUpdate(float deltaTime)
    {
        Transform target = stateMachineClass.SearchMonster();
        if (target)
        {
            agent.SetDestination(stateMachineClass.target.position);

            if (stateMachineClass.getFlagAtk)
            {
                stateMachine.ChangeState<stateAtk>();
                return;
            }

            else if (agent.remainingDistance > agent.stoppingDistance)
            {
                characterController.Move(agent.velocity * Time.deltaTime);
                return;
            }
            
        }
        stateMachine.ChangeState<stateIdle>();
    }

    public override void OnEnd()
    {
        animator?.SetBool("IsFind", false);
        agent.ResetPath();
    }
}