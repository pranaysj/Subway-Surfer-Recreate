using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    private IPlayerStrategy playerStrategy;
    private IStateMachine stateMachine;
    private float jumpDuration; 

    public JumpState(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        playerStrategy = new NormalMovementStrategy();  
    }

    public void Enter()
    {
        // Play jump animation
        playerStrategy.Jump();
        jumpDuration = 1.0f;
    }

    public void Update()
    {
        jumpDuration -= Time.deltaTime;
        if (jumpDuration <= 0) 
        {
            stateMachine.ChangeState(new RunState(stateMachine));
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Jump State");

    }
}
