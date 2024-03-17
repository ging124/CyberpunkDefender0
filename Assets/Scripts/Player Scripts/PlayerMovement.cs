using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float movement { get; private set; }
    public bool canRun = true;

    void FixedUpdate()
    {
        GetMovementInput();
        Running();
    }

    public void Running()
    {
        if(canRun)
        {
            PlayerController.instance.animator.SetFloat("Speed", Mathf.Abs(movement));
            PlayerController.instance.playerFlip.FlipObject();
            PlayerController.instance.rb.velocity = new Vector2(this.movement * this.moveSpeed * Time.fixedDeltaTime, PlayerController.instance.rb.velocity.y);
        }
    }

    public void GetMovementInput()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }
}
 