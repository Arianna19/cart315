using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public int score = 0;
    public int lives = 2;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //dont delete the object when scene is loaded, keep game manager the entire time even after switching scenes
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
        this.lives = 2;
        LoadLevel(1);

    }

    //make sure level 1 is loaded at the start
    private void LoadLevel(int level)
    {
        this.level = level; //what ever that is passed into the faction based off of the first statement variable at the start

        SceneManager.LoadScene("Level" + level); //loading the scene for respective level form string for the current level
    }

}
