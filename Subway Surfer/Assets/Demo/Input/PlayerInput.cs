using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float jumpForce = 6.5f;
    public bool isGounded;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    public void Jump(InputAction.CallbackContext context)
    { 
        isGounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (context.performed && isGounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jump : " + context.phase);
        }

    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        Vector3 move = new Vector3(inputVector.x, 0, inputVector.y);
        playerRb.AddForce(move * 10, ForceMode.Force);
        Debug.Log("Move : " + context.phase + " Value: " + inputVector);
    }
}
