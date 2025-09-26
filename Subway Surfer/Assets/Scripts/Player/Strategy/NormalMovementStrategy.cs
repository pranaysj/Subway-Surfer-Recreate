using Environment;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class NormalMovementStrategy : IPlayerStrategy
{
    private GameObject player;
    private Rigidbody playerRb;
    private BoxCollider playerCollider;
    private Vector3 playerPos;
    private int laneIndex = 1;
    private bool isGrounded = true;

    public NormalMovementStrategy()
    {
        var service = ServiceLocator.GetService<PlayerService>();
        player = service.GetPlayerController().PlayerGameObject();
        playerRb = player.GetComponent<Rigidbody>();
        playerCollider = player.GetComponent<BoxCollider>();
    }

    public void Jump()
    {
        isGrounded = Physics.Raycast(player.transform.position, Vector3.down, 1.1f);
        if (isGrounded)
            playerRb.AddForce(Vector3.up * 6.5f, ForceMode.Impulse);
    }

    public void Roll(float yPosition, float ySize)
    {
        playerCollider.center = new Vector3(0, yPosition, 0);
        playerCollider.size = new Vector3(1, ySize, 1);
        Debug.Log("Normal Roll");
    }

    public void Run()
    {
        //player.transform.position = new Vector3(0, 0, 0);


    }

    public void Dodge(DodgeDirection direction)
    {
        if (direction == DodgeDirection.Left && laneIndex > 0)
        {
            laneIndex--;
            playerPos = player.transform.position;
            playerPos.x -= 2;
            player.transform.position = playerPos;
        }
        else if (direction == DodgeDirection.Right && laneIndex < 2)
        {
            laneIndex++;
            playerPos = player.transform.position;
            playerPos.x += 2;
            player.transform.position = playerPos;
        }
    }
}
