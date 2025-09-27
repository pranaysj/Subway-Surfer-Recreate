using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : IState
{
    private IPlayerStrategy playerStrategy;
    private IStateMachine stateMachine;
    private float fallDuration;

    public FallState(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        playerStrategy = new NormalMovementStrategy();
    }

    public void Enter()
    {
        playerStrategy.Fall();
        fallDuration = 0.5f; // Max fall duration before respawn
    }
    public void Update()
    {
        fallDuration -= Time.deltaTime;

        if (fallDuration <= 0)
        {
            Debug.Log("Player has fallen too long, respawning...");
            stateMachine.ChangeState(new RunState(stateMachine));
        }
    }

    public void Exit()
    {
        fallDuration = 0.5f;
    }

}
