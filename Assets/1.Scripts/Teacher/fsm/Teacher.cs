 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    protected StateMachine<Teacher> fsmManager;
    public StateMachine<Teacher> FsmManager => fsmManager;

    protected UnityEngine.AI.NavMeshAgent agent;
    protected Animator animator;

    private FieldOfView fov;

    public Transform target => fov?.FirstTarget;
    public float atkRange = 0;

    public Transform[] posRoamingLists;
    public Transform posRoaming = null;
    //private int posRoamingListIdx = 0;

    private int roamingPos;

    protected virtual void Start()
    {
        fsmManager = new StateMachine<Teacher>(this, new stateRoaming());
        fsmManager.AddStateList(new stateMove());
        fsmManager.AddStateList(new stateAtk());
        stateIdle stateIdle = new stateIdle();
        stateIdle.flagRoaming = true;
        fsmManager.AddStateList(stateIdle);
        
        fov = GetComponent<FieldOfView>();
    }

    protected virtual void Update()
    {
        fsmManager.Update(Time.deltaTime);
    }

    public virtual Transform SearchMonster()
    {
        return target;
    }

    public Transform getPositionNextRoaming()
    {
        posRoaming = null;

        if (posRoamingLists.Length > 0)
        {
            roamingPos = Random.Range(0, posRoamingLists.Length);
            posRoaming = posRoamingLists[roamingPos];
            //posRoamingListIdx = (posRoamingListIdx + 1) % posRoamingLists.Length;
        }

        return posRoaming;
    }


    public virtual bool getFlagAtk
    {
        get
        {
            if (!target)
            {
                return false;
            }
            float distance = Vector3.Distance(transform.position, target.position);
            return (distance <= atkRange);
        }
    }
}
