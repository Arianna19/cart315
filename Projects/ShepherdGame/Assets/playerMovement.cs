using UnityEngine;
using System.Collections.Generic;
public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigidPoop;
private float moveX; //manage horizontal movement

    void Awake()
    {
        rigidPoop = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //do horizontal movement from player 
        moveX = Input.GetAxis("Horizontal") * moveSpeed; 

    }

    private void FixedUpdate()
    {
        Vector2 velocity = rigidPoop.velocity;
        velocity.x = moveX;
        rigidPoop.velocity = velocity; //set the new velocity to what was previously done
    }
}
