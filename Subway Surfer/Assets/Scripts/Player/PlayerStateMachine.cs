using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : IStateMachine
{
    private IState currentState;

    public void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

}
