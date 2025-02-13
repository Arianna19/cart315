using UnityEngine;

public class Skull : MonoBehaviour
{
    public Rigidbody2D rigidBod { get; private set; } //other things can access the rigid body but only this class can set values
    public float speed = 500f;
    private void Awake()
    {
        this.rigidBod = GetComponent<Rigidbody2D>();
    }
        
    private void Start()
    {
        ResetSkull();
    }

    public void ResetSkull()
    {
        this.transform.position = Vector2.zero;
        this.rigidBod.velocity = Vector2.zero;
        Invoke(nameof(SetRandomMovement), 1f); //create a delay for the game

    }

    //delay the start of the skull movement
    private void SetRandomMovement()
    {
        Vector2 force = Vector2.zero;
        //so that the skull goes left or right randomly 
        force.x = Random.Range(-1f, 1f);
        //always want the skull to go down so y will stay the same 
        force.y = -1f;

        //add this new force to the rigid body
        this.rigidBod.AddForce(force.normalized * this.speed); //return to 1 with the normalized
    }
}
