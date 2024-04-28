using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerSpeed;
    [SerializeField] private Rigidbody2D playerRigidBody;
    
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.velocity = new Vector2(horizontalInput * playerSpeed, verticalInput * playerSpeed);
    }


    void Update()
    {
        Movement();
    }
}
