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
        //Other Input like Move, Roll
    }

}
