using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackState : State
{
    Agent owner;

    public attackState(Agent owner) { this.owner = owner; }
    public override void Enter()
    {
        Debug.Log("Entering attack");

    }
    public override void Execute()
    {
        Debug.Log("Execute attack");

    }
    public override void Exit()
    {
        Debug.Log("Exiting attack");

    }

}

