using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedToRotate = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if keys are down move accordingly
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { //turn the paddle to the left

            transform.Rotate(Vector3.forward, -speedToRotate * Time.deltaTime); //the axis in which it will move on 

        }

        //if keys are down move accordingly to the opposite direction
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { //turn the paddle to the right

            transform.Rotate(Vector3.forward, speedToRotate * Time.deltaTime); //the axis in which it will move on going the opposite way


        }
    }
}
