using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Assign in the Inspector
    [Header("Movement Settings")]
    public float laneDistance = 4f; // Distance between lanes (e.g., -4, 0, 4)
    public float moveSpeed = 8f;    // Forward running speed
    public float jumpForce = 10f;   // Vertical force for the jump
    public float gravity = 20f;     // Downward force (always applied)

    // Private variables
    private CharacterController controller;
    private int currentLane = 1;    // 0: Left, 1: Middle, 2: Right
    private Vector3 moveDirection;  // Stores the direction of movement (forward and vertical)
    [SerializeField] AnimationCurve jumpCurve; // Animation curve for jump

    void Start()
    {
        controller = GetComponent<CharacterController>(); 

        moveDirection.z = moveSpeed;
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currentLane > 0)
                {
                    currentLane--;
                }
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentLane < 2)
                {
                    currentLane++;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveDirection.y = jumpForce;
                jumpCurve.Evaluate(0); //
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        //Debug.Log("Vertical Speed (Y): " + moveDirection.y);
        float targetX = (currentLane - 1) * laneDistance;

        float newX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * 10f);

        moveDirection.x = newX - transform.position.x; // Set X movement to the difference needed for the Lerp

        controller.Move(moveDirection * Time.deltaTime);

    }
}