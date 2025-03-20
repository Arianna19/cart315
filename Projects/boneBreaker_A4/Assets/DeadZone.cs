using UnityEngine;

public class DeadZone : MonoBehaviour
{
    //check if the bot bound is touching the ball and if so its considered a miss or the player loses a life
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Skull")
        {
            FindObjectOfType<GameManager>().Missed();
;
        }
    }
}
