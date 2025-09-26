using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class RollCommand : ICommand
{
    public IStateMachine stateMachine;
    public RollCommand()
    {
        stateMachine = ServiceLocator.GetService<IStateMachine>();
    }
    public void Execute()
    {
        stateMachine.ChangeState(new RollState(stateMachine));
    }
}
