using System.Collections;
using UnityEngine;
public class BallScript : MonoBehaviour {
    public float ballSpeed = 2;
    private int[] directionsOptions = {-1,1};
    private int hDir, vDir;

    public int score1, score2;

    public AudioSource blip;


    private RigidBody2D rb; //rigid body accronym 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCorountine(rountine: Launch());
    }

    public void OnCollisionEnter2D(Collision2D wall) {

        if (wall.gameObject.name == "leftWall") {
            //give points to player 2
            score2 += 1;
            Reset();
        }

         if (wall.gameObject.name == "rightWall") {
            //give points to player 2
            score1 += 1;
            Reset();
        }

        if (wall.gameObject.name == "topWall" || wall.gameObject.name == "bottomWall") {
            blip.pitch = 1f;
            blip.Play();
    
        }
        


    }

    void Update() {

    }

    private IEnumerator Launch() {
        // choose random x dir 
        hDir = directionsOptions[Random.Range(0, directionOptions.Length)];

        vDir = directionsOptions[Random.Range(0, directionOptions.Length)];
        Random.Range(0, directionOptions.Length);

        // choose random y dir
        yield return new WaitForSeconds(1);


        rb.AddForce(transform.right * ballSpeed * hDir); // Randomly go Left or Right
        // Add a vertical force
        rb.AddForce(transform.up * ballSpeed * vDir); // Randomly go Up or Dow
    }


    void Reset () {
        rb.linearVelocity = Vector2.zero;
        this.transform.localPosition = new Vector3(0,0,0);
        //launch
        StartCoroutine(rountine.Launch());

    }
}


