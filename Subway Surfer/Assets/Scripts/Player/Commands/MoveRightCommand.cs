using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class MoveRightCommand : ICommand
{
    private IStateMachine stateMachine;
    
    public MoveRightCommand(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public void Execute()
    {
        stateMachine.ChangeState(new DodgeState(stateMachine, DodgeDirection.Right));
    }
}
