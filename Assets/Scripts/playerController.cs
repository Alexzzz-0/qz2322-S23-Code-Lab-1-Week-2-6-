using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    /// Detect to go or to turn
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// make an enum array to store the information of the player's current facing direction
    /// use the playerFace to compare with the command currently received
    /// if it is the same, move; or turn to that direction
    public enum playerDirection
    {
        left,
        right,
        up,
        down
    }

    private playerDirection playerFace = playerDirection.right;

    private GameObject player;

    public bool isExecutingTurn = false;
    public bool isExecutingMove = false;

    private Vector3 moveDis;
    
    public Vector3 MoveOrTurn(float moveLength)
    {
        player = GameObject.FindWithTag("Player");
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerFace == playerDirection.left)
            {
                if (isExecutingTurn == false)
                {
                    //Debug.Log("Move Left!");
                    isExecutingMove = true;
                    moveDis = player.GetComponent<player>().Move(moveLength);
                }
            }
            else
            {
                if (isExecutingMove == false)
                {
                    //Debug.Log("Turn Left!");
                    isExecutingTurn = true;
                    playerFace = playerDirection.left;
                    player.GetComponent<player>().assignTurnFace(playerFace);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerFace == playerDirection.right)
            {
                if (isExecutingTurn == false)
                {
                    //Debug.Log("Move Right!");
                    isExecutingMove = true;
                    moveDis = player.GetComponent<player>().Move(moveLength);
                }
            }
            else
            {
                if (isExecutingMove == false)
                {
                    //Debug.Log("Turn Right!");
                    isExecutingTurn = true;
                    playerFace = playerDirection.right;
                    player.GetComponent<player>().assignTurnFace(playerFace);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (playerFace == playerDirection.up)
            {
                if (isExecutingTurn == false)
                {
                    //Debug.Log("Move Up!");
                    isExecutingMove = true;
                    moveDis = player.GetComponent<player>().Move(moveLength);
                }
            }
            else
            {
                if (isExecutingMove == false)
                {
                    //Debug.Log("Turn Up!");
                    isExecutingTurn = true;
                    playerFace = playerDirection.up;
                    player.GetComponent<player>().assignTurnFace(playerFace);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (playerFace == playerDirection.down)
            {
                if (isExecutingTurn == false)
                {
                    //Debug.Log("Move Down!");
                    isExecutingMove = true;
                    moveDis = player.GetComponent<player>().Move(moveLength);
                }
            }
            else
            {
                if (isExecutingMove == false)
                {
                    //Debug.Log("Turn Down!");
                    isExecutingTurn = true;
                    playerFace = playerDirection.down;
                    player.GetComponent<player>().assignTurnFace(playerFace);
                }
            }
        }

        return moveDis;
    }
    
}
