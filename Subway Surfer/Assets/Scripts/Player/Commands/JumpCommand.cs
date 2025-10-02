using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class JumpCommand : ICommand
{
    private IStateMachine stateMachine;
    public JumpCommand(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public void Execute()
    {
        stateMachine.ChangeState(new JumpState(stateMachine));
    }

}
