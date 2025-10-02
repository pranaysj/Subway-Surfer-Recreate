using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using Utilities;

public class InputService
{
    private IStateMachine stateMachine;

    public event Action<ICommand> OnCommandIssued;

    public InputService()
    {
        stateMachine = ServiceLocator.GetService<IStateMachine>();
    }

    public void PollInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnCommandIssued?.Invoke(new JumpCommand(stateMachine));
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            OnCommandIssued?.Invoke(new RollCommand(stateMachine));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnCommandIssued?.Invoke(new MoveLeftCommand(stateMachine));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnCommandIssued?.Invoke(new MoveRightCommand(stateMachine));
        }
    }

}