using Environment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
    private IPlayerStrategy playerStrategy;
    private IStateMachine stateMachine;

    public RunState(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        playerStrategy = new NormalMovementStrategy();
    }
    public void Enter()
    {
        playerStrategy.Run();
    }
    public void Update()
    {
    }

    public void Exit()
    {
    }

}
