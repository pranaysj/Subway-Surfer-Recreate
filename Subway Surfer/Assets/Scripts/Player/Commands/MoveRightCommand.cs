using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class MoveRightCommand : ICommand
{
    private IStateMachine stateMachine;
    
    public MoveRightCommand()
    {
        stateMachine = ServiceLocator.GetService<IStateMachine>();
    }
    public void Execute()
    {
        stateMachine.ChangeState(new DodgeState(stateMachine, DodgeDirection.Right));
    }
}
