using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class MoveLeftCommand : ICommand
{
    private IStateMachine stateMachine;
    public MoveLeftCommand(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public void Execute()
    {
        stateMachine.ChangeState(new DodgeState(stateMachine, DodgeDirection.Left));
    }
}
