using Environment;
using Main;
using Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Utilities;

public class NormalMovementStrategy : IPlayerStrategy
{
    private GameObject player;
    public Rigidbody playerRb;
    private BoxCollider playerCollider;
    private Vector3 playerPos;
    private int laneIndex = 1;
    public bool isGrounded = true;
    private float jumpSpeed = 6.5f;
    private float fallSpeed = 4.5f;
    Vector3 targetPos;
    private float gravityIncrease = 20.0f;

    public NormalMovementStrategy()
    {
        var service = ServiceLocator.GetService<PlayerService>();
        player = service.GetPlayerController().PlayerGameObject();
        playerRb = player.GetComponent<Rigidbody>();
        playerCollider = player.GetComponent<BoxCollider>();
    }

    
    public void Jump()
    {
        isGrounded = Physics.Raycast(player.transform.position, Vector3.down, 0.7f);
        
        if (isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
            
    }
    public void Fall()
    {
        playerRb.AddForce(Vector3.down * fallSpeed, ForceMode.Impulse);
        

        //Debug.Log("Falling...");
        //Physics.gravity = new Vector3(0, -gravityIncrease, 0);
        //Debug.Log(Physics.gravity);
    }

    public void Roll(float yPosition, float ySize)
    {
        playerCollider.center = new Vector3(0, yPosition, 0);
        playerCollider.size = new Vector3(1, ySize, 1);
    }

    public void Run()
    {
        //Physics.gravity = new Vector3(0, -9.81f, 0);
    }


    public void Dodge(DodgeDirection direction)
    {
        Vector3 playerPos = player.transform.position;

        if (direction == DodgeDirection.Left && laneIndex >= 0)
        {
            laneIndex--;
            playerPos.x -= 2;
        }
        else if (direction == DodgeDirection.Right && laneIndex <= 2)
        {
            laneIndex++;
            playerPos.x += 2;
        }

        targetPos = playerPos;
        GameService.Instance.StartCoroutine(DodgeToPosition(targetPos));
    }
    private IEnumerator DodgeToPosition(Vector3 target)
    {
        float duration = 0.2f;
        float elapsed = 0f;
        Vector3 start = player.transform.position;

        while (elapsed < duration)
        {
            player.transform.position = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        player.transform.position = target; // Snap to final position
    }

}
