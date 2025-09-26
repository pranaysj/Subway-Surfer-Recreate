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
        playerStrategy.Roll(-0.5f, 1);
        rollDuration = 1.0f;
    }

    public void Update()
    {
        rollDuration -= Time.deltaTime;

        if (rollDuration <= 0) 
        {
            playerStrategy.Roll(0.0f,2); // Reset collider size after roll
            stateMachine.ChangeState(new RunState(stateMachine));
        }
    }

    public void Exit()
    {
    }
}
