using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody playerRb;
    private float jumpForce = 9.5f;
    public bool isGounded;
    float maxdis = 0;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    public void Jump(InputAction.CallbackContext context)
    { 
        Physics.gravity = new Vector3(0, -9.81f, 0);

        isGounded = Physics.Raycast(transform.position, Vector3.down, 1.2f);

        if (context.performed && isGounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
    private void Update()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red);
        if (transform.position.y > maxdis)
        {
            maxdis = transform.position.y;
        }
        if (!isGounded && playerRb.velocity.y < 0)
        {
            Debug.Log("Falling...");
            //var y = transform.position;
            //y.y -= 5.0f * Time.deltaTime;
            //transform.position = y;
            Physics.gravity = new Vector3(0, -20, 0);
            isGounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var target = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            StartCoroutine(DodgeToPosition(target));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var target = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            StartCoroutine(DodgeToPosition(target));
        }
    }
    private IEnumerator DodgeToPosition(Vector3 target)
    {
        float duration = 0.2f;
        float elapsed = 0f;
        Vector3 start = transform.position;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target; // Snap to final position
    }
    private void FixedUpdate()
    {

    }
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        Vector3 move = new Vector3(inputVector.x, 0, inputVector.y);
        playerRb.AddForce(move * 10, ForceMode.Force);
        Debug.Log("Move : " + context.phase + " Value: " + inputVector);
    }
}
