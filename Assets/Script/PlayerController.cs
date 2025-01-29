using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
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
        //boutons q et d
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        //applique le mouvement
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
    }
}
