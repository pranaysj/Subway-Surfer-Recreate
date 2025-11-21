using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    //[RequireComponent(typeof(Rigidbody))]
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;
        private Rigidbody rb;
        [SerializeField]private bool isGrounded;

        [Header("Movement")]
        public float moveDistance = 2f;
        public float speed = 5f; // horizontal move speed (units/sec)
        public float minX = -2f;
        public float maxX = 2f;

        [Header("Jump / Fall")]
        public float jumpVelocity = 6f;
        public float fastFallSpeed = 10f;

        private Vector3 targetPos;

        // input flags
        bool jumpRequested = false;
        bool fastFallRequested = false;

        bool isMove = false;


        internal void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            targetPos = transform.position;
        }

        private void Update()
        {
            // --- Input collection (non-physics) ---
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                jumpRequested = true;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && !isGrounded)
            {
                fastFallRequested = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                float x = targetPos.x + moveDistance;
                x = Mathf.Min(x, maxX);
                targetPos = new Vector3(x, targetPos.y, targetPos.z);
                isMove = true;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                float x = targetPos.x - moveDistance;
                x = Mathf.Max(x, minX);
                targetPos = new Vector3(x, targetPos.y, targetPos.z);
                isMove = true;
            }
        }

        private void FixedUpdate()
        {
            // --- Apply jump ---
            if (jumpRequested)
            {
                Vector3 v = rb.velocity;
                v.y = jumpVelocity;
                rb.velocity = v;
                jumpRequested = false;
                // we set isGrounded false immediately to avoid multi-jumps from collision frame timing
                isGrounded = false;
            }

            // --- Apply fast-fall ---
            if (fastFallRequested)
            {
                Vector3 v = rb.velocity;
                v.y = -fastFallSpeed;
                rb.velocity = v;
                fastFallRequested = false;
            }

            float newX = Mathf.MoveTowards(transform.position.x, targetPos.x, speed * Time.fixedDeltaTime);

            if(isMove)
            {

                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
                //transform.position.x = newX;
                if(newX == targetPos.x)
                {
                    isMove = false;
                }
            }


        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }

        // optional: OnDrawGizmos to see lanes in editor
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position + Vector3.right * minX, 0.1f);
            Gizmos.DrawWireSphere(transform.position + Vector3.right * maxX, 0.1f);

        }
    }
}