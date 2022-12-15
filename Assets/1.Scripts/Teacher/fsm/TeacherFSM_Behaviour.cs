using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using System.Reflection.Emit;

public class TeacherFSM_Behaviour : Teacher
{
    public LayerMask targetLayerMask;

    protected override void Start()
    {
        base.Start();
        fsmManager.AddStateList(new stateMove());
        fsmManager.AddStateList(new stateAtk());
    }

    protected override void Update()
    {
        base.Update();
    }


    public override bool getFlagAtk
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

    public J ChangeState<J>() where J : State<Teacher>
    {
        return fsmManager.ChangeState<J>();
    }

    override public Transform SearchMonster()
    {
        return target;
    }
}
