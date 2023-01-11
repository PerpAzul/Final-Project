using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float jumpSpeed;
    [SerializeField] private LayerMask groundLayer;
    
    private Rigidbody body;
    private Animator ani;
    private BoxCollider box;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        box = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        //Moves left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(horizontalInput * speed, body.velocity.y, body.velocity.z);
    
        //Rotates the player to face the right direction
        if (horizontalInput > 0.01f)
        {
            float newXScale = -2f;
            transform.localScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
        }
        if (horizontalInput < -0.01f)
        {
            float newXScale = 2f;
            transform.localScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
        }
        
        //Jumps
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }
        
        //Sets the animation
        ani.SetBool("Run", horizontalInput != 0);
    }

    private void Jump()
    {
        body.velocity = new Vector3(body.velocity.x, jumpSpeed, body.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
      
    }

    private bool isGrounded()
    {
        RaycastHit raycastHit = Physics.BoxCast(box.bounds.center, box.bounds.size/2, Vector3.down, , 0.1f, groundLayer);
        return false;
    }
}
