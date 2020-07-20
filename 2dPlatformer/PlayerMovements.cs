using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public PlayerController controller;
    public float runSpeed = 400f;
    public float jumpPower = 20f;

    private float horizontalInput = 0f;
    private bool jumpPressed = false;


    void FixedUpdate()
    {
        ReadInput();
        controller.HorizontalMove(GetHorizontalVelocity());

        if (jumpPressed)
        {
            controller.Jump(jumpPower);
        }
            
    }

    private void ReadInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * runSpeed;
        jumpPressed = Input.GetAxisRaw("Jump") > 0;
    }

    private float GetHorizontalVelocity()
    {
        return horizontalInput * Time.fixedDeltaTime;
    }
}
