using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class MoveLeftCommand : ICommand
{
    private IStateMachine stateMachine;
    public MoveLeftCommand()
    {
        stateMachine = ServiceLocator.GetService<IStateMachine>();
    }
    public void Execute()
    {
        stateMachine.ChangeState(new DodgeState(stateMachine, DodgeDirection.Left));
    }
}
