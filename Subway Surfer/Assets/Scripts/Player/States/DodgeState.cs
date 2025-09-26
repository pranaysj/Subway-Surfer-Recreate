using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public enum DodgeDirection
{
    Left,
    Right
}

public class DodgeState : IState
{
    private IPlayerStrategy playerStrategy;
    private IStateMachine stateMachine;
    private DodgeDirection dodgeDirection;
    private float dodgeDuration;

    public DodgeState(IStateMachine stateMachine, DodgeDirection direction)
    {
        this.stateMachine = stateMachine;
        this.dodgeDirection = direction;
        playerStrategy = new NormalMovementStrategy();
    }
    public void Enter()
    {
        // Play dodge animation
        dodgeDuration = 2.0f;

        if(dodgeDirection == DodgeDirection.Left)
            playerStrategy.Dodge(DodgeDirection.Left);
        else if(dodgeDirection == DodgeDirection.Right)
            playerStrategy.Dodge(DodgeDirection.Right);
    }

    public void Update()
    {
        dodgeDuration -= Time.deltaTime;
        if (dodgeDuration <= 0)
        {
            stateMachine.ChangeState(new RunState(stateMachine));
        }
    }
    public void Exit()
    {
    }
}
