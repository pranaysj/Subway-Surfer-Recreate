using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class InputController : MonoBehaviour
{
    private InputService inputService;
    private void Start()
    {
        inputService = ServiceLocator.GetService<InputService>();
        inputService.OnCommandIssued += HandleCommand;
    }

    private void Update()
    {
        inputService.PollInput();
    }

    private void HandleCommand(ICommand command)
    {
        command.Execute();
    }

    private void OnDestroy()
    {
        inputService.OnCommandIssued -= HandleCommand;
    }

}
