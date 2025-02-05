using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cellBall : MonoBehaviour
{
    Rigidbody2D rigidbod;
    int randomRotation;
    float speedWoosh = 3f;
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
        //go to the wait for player function when the game starts to not get the ball moving 24/7
        StartCoroutine(waitForPlayer());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //for the cell to wait until the player interacts for it to start moving
    private IEnumerator waitForPlayer() 
    {

        yield return new WaitForSeconds(1.5f);
        //start the cell ball movement/velocity
        rigidbod.velocity = transform.up * speedWoosh;

    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("gameOver"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
