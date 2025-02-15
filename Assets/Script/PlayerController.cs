using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool isGrounded;
    private Rigidbody rb;
    
    void Start()
    {
        //recupere le composant sur le joueur
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        //recupere les input du joueur
        float moveHorizontal = Input.GetAxis("Horizontal");
        // boutons z et s
        float moveVertical = Input.GetAxis("Vertical");
        float moveHeight = Input.GetAxis("Jump");
        //boutons q et d
        Jump();

        
        
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        
        //applique le mouvement
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        if (!isGrounded)
        {
            return;
        }

        if (Input.GetAxis("Jump") != 1f)
        {
            return;
        }
        Vector3 jumpVector = new Vector3(0f, jumpForce, 0f);
        rb.AddForce(jumpVector, ForceMode.Impulse);
    }
}
