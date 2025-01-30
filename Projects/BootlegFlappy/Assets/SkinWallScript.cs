using UnityEngine;

public class SkinWallScript : MonoBehaviour
{

    public float moveSpeed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime; //vector3 cause there's 3 points
    }
}
