using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Skull skull {get; private set; }
    public Platform platform {get; private set; }
    private Bone[] bones;
    public int level = 1;
    public int score = 0;
    public int lives = 2;
    private void Awake()
    {
    
        DontDestroyOnLoad(this.gameObject); //dont delete the object when scene is loaded, keep game manager the entire time even after switching scenes
        //setting that unity provides to be able to switch and reload scenes
        SceneManager.sceneLoaded += OnLevelLoaded;

    }
    
    
    void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        //want to load and start at level 1
        //reset the score to zero 
        //reset the lives back to the beginning amount
        this.score = 0;
        this.lives = 3;
        LoadLevel(1);

    }

    //make sure level 1 is loaded at the start
    private void LoadLevel(int level)
    {
        this.level = level; //what ever that is passed into the faction based off of the first statement variable at the start

        SceneManager.LoadScene("Level" + level); //loading the scene for respective level form string for the current level
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        //create the reference for the skull and platform
        this.skull = FindObjectOfType<Skull>();
        this.platform = FindObjectOfType<Platform>();
    }

    private void ResetLevel()
    {
        //reset the ball 
        //reset the paddle
        //dont reset the bricks to keep progress
        this.skull.ResetSkull();
        this.platform.resetPlatform();
    }

    private void GameOver()
    {
        NewGame(); //just restart the game
    }

    public void Missed()
    {
        //decrease the amount of lives left
        this.lives--;
        //if the player still has lives left the game restarts 
        if (this.lives > 0)
        {
            ResetLevel();
        } else { //if there's no more lives left switch to game over
            GameOver();
        }
    }

    public void Hit(Bone bone)
    {
        this.score += bone.points; //pass the amount of points when the bone is hit
        if (Cleared()) 
        {
            LoadLevel(this.level + 1);
        }
    }

    //check if player has cleared all the bones or broke them 
    private bool Cleared()
    {
        for (int i = 0; i < this.bones.Length; i++)
        {
            if (this.bones[i].gameObject.activeInHierarchy && !this.bones[i].unbreakable) //check if the object is active either when or not destroyed ignore the unbreakable bones
            {
                return false; //if theres a single bone active then the game has not been cleared 
            }
        }

        return true; //if there's no more active bones in the scene
    }
}
