using UnityEngine;

public class SkinWallScript : MonoBehaviour
{

    public float moveSpeed = 5;
    public float deadSkin = -45; //delete the pipes after they pass this location

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime; //vector3 cause there's 3 points

        if (transform.position.x < deadSkin)
        {
            Debug.Log("Skin dead/deleted"); //console log moment for Unity
            Destroy(gameObject); //cool thing that destroys the object by itself just with one line of code
        }
    }
}
