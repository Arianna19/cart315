using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreT;
    public static int scorePoints = 0;
    
    void Start()
    {
        scorePoints = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
        scoreT.text = scorePoints.ToString();

    }
}
