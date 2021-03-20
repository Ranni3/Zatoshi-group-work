using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float playerSpeed = 10f;
    public float gravity = -9.8f;
    public float jump = 15.0f;

    Vector3 gravityAccelatarion;

    public Transform groundChecker;
    public LayerMask ground;

    bool isGrounded;

    public float playerHealth = 100;
    public bool gameOver = false;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, 0.4f, ground);

        if(isGrounded && gravityAccelatarion.y < 0)
        {
            gravityAccelatarion.y = 0.1f;
        }
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xMovement + transform.forward * zMovement;

        controller.Move(move * playerSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            gravityAccelatarion.y = jump;
        }

        gravityAccelatarion.y += gravity * Time.deltaTime;

        controller.Move(gravityAccelatarion * Time.deltaTime);

        if(playerHealth ==0f)
        {
            gameOver = true;
        }
    }
    
}
