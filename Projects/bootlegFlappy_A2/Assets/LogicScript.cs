using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //a thing that triggers scene changes in unity

public class LogicScript : MonoBehaviour
{

    public GameObject cellDeadScreen;
    public void restartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        cellDeadScreen.SetActive(true); //this is triggered when the cell crashed into a skin wall

    }

}
