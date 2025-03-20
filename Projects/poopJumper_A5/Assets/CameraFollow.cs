using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//basically how the camera will follow the player's progress on the game
public class CameraFollow : MonoBehaviour
{
    public Transform targetPoop;

    private void LateUpdate()
    {
        //if the players position is greater than the camera's position
        if (targetPoop.position.y > transform.position.y)
        {
            //all the axes that need to change depending on this statement
            Vector3 newPosition = new Vector3(transform.position.x, targetPoop.position.y, transform.position.z);
            transform.position = newPosition; //what we perviously set is noww the new transform.position
        }
    }
}
