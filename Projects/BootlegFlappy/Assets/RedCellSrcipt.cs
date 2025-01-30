using UnityEngine;

public class RedCellSrcipt : MonoBehaviour
{
    public Rigidbody2D myRigidbody; //create a communicatoin link between rigidbody and code
    public float movementStrength; //creates a domain in unity to modify the jump speed
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true) //if space bar is pressed down go up
        {
        myRigidbody.linearVelocity = Vector2.up * movementStrength; //jump movement 
        }
    }
}
