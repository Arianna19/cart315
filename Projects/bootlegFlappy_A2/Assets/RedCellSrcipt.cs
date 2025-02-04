using UnityEngine;

public class RedCellSrcipt : MonoBehaviour
{
    public Rigidbody2D myRigidbody; //create a communicatoin link between rigidbody and code
    public float movementStrength; //creates a domain in unity to modify the jump speed
    public LogicScript logic;
    public bool cellIsLiving = true;
    void Start()
    {
       logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && cellIsLiving == true) //if space bar is pressed down go up and the cell is alive
        {
        myRigidbody.linearVelocity = Vector2.up * movementStrength; //jump movement 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        cellIsLiving = false; //kill the cell or stop cell from moving if this collision happens
    }


}
