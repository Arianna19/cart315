using UnityEngine;

public class cellBall : MonoBehaviour
{
    Rigidbody2D rigidbod;
    int randomRotation;
    float speedWoosh = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //give ball a starting velocity to start the game, or else nothing happens
        //rotate to a random direction 
        //apply a force to the selected random direction
        rigidbod = GetComponent<Rigidbody2D>();
        randomRotation = Random.Range(0,361);
        //rotate the object with the new given randomRoation previously stated
        transform.Rotate(transform.forward, randomRotation); 
        
        rigidbod.velocity = transform.up * speedWoosh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
