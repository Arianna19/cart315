using UnityEngine;

public class Platform : MonoBehaviour
{
    public new Rigidbody2D rigidBod { get; private set; } //other things can access the rigid body but only this class can set values
    public Vector2 direction { get; private set; } //store the direction in which the paddle is moving
    public float speed = 30f; //speed of the paddle movement
    public float maxBounceAngle = 75f; //never make the skull go fully flat when bouncing on the platform

    private void Awake()
    {
        this.rigidBod = GetComponent<Rigidbody2D>(); //function that will look at the gameobject script is on and get any component from it
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.direction = Vector2.left; //left movement
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            this.direction = Vector2.right; //right movement
        } else {
            this.direction = Vector2.zero; //not moving at all
        }
    }
   
   //this is  used when using physics and it called at a fixed interval so a specific moment
    private void FixedUpdate()
    {
        if (this.direction != Vector2.zero)
        {
            this.rigidBod.AddForce(this.direction * this.speed); //scalling the vector by the speed
        }
    }
    //to make different reactions based on where the skull falls on the milk carton
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //detect the skull is hitting the paddle and nothing else 
        Skull skull = collision.gameObject.GetComponent<Skull>();

        if (skull != null)
        {
            Vector3 platformPosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point; //specify the point of contact since there can be multiple

            float offset = platformPosition.x - contactPoint.x; //gives the offset value 
            //get percentage of half width of the platform
            float platformWidth = collision.otherCollider.bounds.size.x / 2; 
            //calculate angle and rotation to make the skull bounce based off of the location
            float currentAngle = Vector2.SignedAngle(Vector2.up, skull.GetComponent<Rigidbody2D>().linearVelocity);
            //calculate bounce angle
            float bounceAngle = (offset / platformWidth);
            //ajust the new bounce to the skull by limting it and adding all the new rules of it  
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);

            //make the new rotation of the skull after getting the new angles 
            //make the skull move in the direction based off of the rotation it gets
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);

            //take all of this and update the rigidbody of the skull
            skull.GetComponent<Rigidbody2D>().linearVelocity = rotation * Vector2.up * skull.GetComponent<Rigidbody2D>().linearVelocity.magnitude;

        }
    }
}
