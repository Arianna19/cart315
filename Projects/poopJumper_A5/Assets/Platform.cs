using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Platform : MonoBehaviour
{
    public float jumping = 10f; //set to 10 by default
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //boost the poop person upwards so that they can jump onto the next platform
        if (collision.relativeVelocity.y <= 0f) //if the velocity is less than equal to zero 
        {
            Rigidbody2D rigidPoop = collision.gameObject.GetComponent<Rigidbody2D>(); 
            if (rigidPoop != null)
            {
                Vector2 velocity = rigidPoop.velocity;
                velocity.y = jumping;
                rigidPoop.velocity = velocity; //set the players velocity back to this new velocity
            }
        }
    }
}
