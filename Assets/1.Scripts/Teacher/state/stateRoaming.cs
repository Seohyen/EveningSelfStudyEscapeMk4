using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class stateRoaming : State<Teacher>
{
    private Animator animator;
    private CharacterController controller;
    private NavMeshAgent agent;

    private Teacher teacher;

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        controller = stateMachineClass.GetComponent<CharacterController>();
        agent = stateMachineClass.GetComponent<NavMeshAgent>();

        teacher = stateMachineClass as Teacher;
    }
    public override void OnStart()
    {
        Debug.Log("state Roaming");

        if (stateMachineClass?.posRoaming == null)
        {
            stateMachineClass.getPositionNextRoaming();
        }
        if (stateMachineClass?.posRoaming)
        {
            Vector3 destination = stateMachineClass.posRoaming.position;
            agent?.SetDestination(destination);
            animator?.SetBool("IsWalk", true);
            agent.speed = 3.0f;
        }

    }
    public override void OnUpdate(float deltaTime)
    {
        Transform target = stateMachineClass.SearchMonster();
        if (target)
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
        else
        {
            if (!agent.pathPending && (agent.remainingDistance <= agent.stoppingDistance))
            {
                Transform nexRoamingPosition = stateMachineClass.getPositionNextRoaming();
                if (nexRoamingPosition)
                {
                    agent.SetDestination(nexRoamingPosition.position);
                }
                stateMachine.ChangeState<stateIdle>();
            }
            else
            {
                controller.Move(agent.velocity * Time.deltaTime);

            }
        }
    }
    public override void OnEnd()
    {
        animator?.SetBool("IsWalk", false);
        agent.ResetPath();
    }
}