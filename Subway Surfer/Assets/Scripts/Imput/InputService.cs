using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService 
{
    public event Action<ICommand> OnCommandIssued;

    public void PollInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnCommandIssued?.Invoke(new JumpCommand());
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            OnCommandIssued?.Invoke(new RollCommand());
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnCommandIssued?.Invoke(new MoveLeftCommand());
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnCommandIssued?.Invoke(new MoveRightCommand());
        }
    }

}
