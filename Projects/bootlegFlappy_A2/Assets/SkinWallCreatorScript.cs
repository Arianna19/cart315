using UnityEngine;

public class SkinWallCreatorScript : MonoBehaviour
{
    public GameObject skin;
    public float spawnCreation = 2; //how many seconds pass untill the next one is spawned
    public float randomHeightOffset = 10;
    private float spawnTimer = 0; //private cause we won't be changing it in unity

    void Start()
    {
        spawnSkin(); //go to the function as soon as the game starts to form a skinwall immediately
    }

    void Update()
    {
        if (spawnTimer < spawnCreation) //every frame asks if timer is less than spawnCreation
        {
            spawnTimer = spawnTimer + Time.deltaTime; //create number that counts up every frame
        }
        else //spawnTimer has met or gone over the spawnCreation
        {
        spawnSkin();
        spawnTimer = 0;
        }
    }

    void spawnSkin()
    {
        //only be used within the function
        float lowestPoint = transform.position.y - randomHeightOffset; 
        float heighestPoint = transform.position.y + randomHeightOffset;

        Instantiate(skin, new Vector3(transform.position.x, Random.Range(lowestPoint, heighestPoint), 0), transform.rotation); //defining all 3 axes
        
    }
}
