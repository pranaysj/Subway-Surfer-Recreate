using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class NormalMovementStrategy : IPlayerStrategy
{
    private GameObject player;
    private Rigidbody playerRb;
    private bool isGrounded = true;

    public NormalMovementStrategy()
    {
        var service = ServiceLocator.GetService<PlayerService>();
        player = service.GetPlayerController().PlayerTransform();
        playerRb = player.GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        isGrounded = Physics.Raycast(player.transform.position, Vector3.down, 1.1f);
        if (isGrounded)
            playerRb.AddForce(Vector3.up * 6.5f, ForceMode.Impulse);
        Debug.Log("Normal Jump");
    }

    public void Roll()
    {
        //change change the player's collider size to simulate a roll
        Debug.Log("Normal Roll");
    }

    public void Run()
    {
        //only play the run animation
        Debug.Log("Normal Run");
    }
}
