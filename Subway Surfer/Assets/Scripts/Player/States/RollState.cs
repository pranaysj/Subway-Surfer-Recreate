using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : IState
{
    private IPlayerStrategy playerStrategy;
    private IStateMachine stateMachine;

    private float rollDuration;

    public RollState(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        playerStrategy = new NormalMovementStrategy();
    }
    public void Enter()
    {
        // Play roll animation
    }

    public void Update()
    {

        rollDuration -= Time.deltaTime;

        if (rollDuration <= 0) 
        {
            stateMachine.ChangeState(new RunState(stateMachine));
        }
    }

    public void Exit()
    {
        playerStrategy.Roll();
        rollDuration = 0.5f;
    }
}
