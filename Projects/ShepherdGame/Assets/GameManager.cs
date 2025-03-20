using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManager
using TMPro; // Import TextMeshPro for UI text
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player; // Reference to the player
    public int totalPlatforms = 300;
    public float platformSpacing = 2.0f;
    public int maxPlatformsOnScreen = 5;
    public float spawnYOffset = 5f;
    public float fallThreshold = -3f; // Y-position where game restarts

    private List<GameObject> activePlatforms = new List<GameObject>();
    private float highestPlatformY = 0f;

    public TMP_Text survivalTimeText; // UI text reference for survival time
    private float survivalTime = 0f; // Time the player has survived in seconds

    void Start()
    {
        // Spawn initial platforms
        for (int i = 0; i < maxPlatformsOnScreen; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // Update survival time
        survivalTime += Time.deltaTime; // Increase time by the frame's delta time

        // Update the timer UI
        UpdateSurvivalTimeUI();

        // Spawn new platforms as player moves up
        if (player.position.y + spawnYOffset > highestPlatformY)
        {
            SpawnPlatform();
        }

        // Remove platforms below player
        RemoveOffscreenPlatforms();

        // Check if player has fallen
        if (player.position.y < fallThreshold)
        {
            RestartGame();
        }
    }

    void SpawnPlatform()
    {
        if (activePlatforms.Count >= totalPlatforms) return;

        float xPos = Random.Range(-5f, 5f);
        float yPos = highestPlatformY + Random.Range(1.5f, platformSpacing);
        Vector3 spawnPosition = new Vector3(xPos, yPos, 0);

        GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        activePlatforms.Add(newPlatform);
        highestPlatformY = yPos;
    }

    void RemoveOffscreenPlatforms()
    {
        for (int i = activePlatforms.Count - 1; i >= 0; i--)
        {
            if (activePlatforms[i].transform.position.y < player.position.y - 10f)
            {
                Destroy(activePlatforms[i]);
                activePlatforms.RemoveAt(i);
            }
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the current scene
    }

    // Updates the survival time UI text
    void UpdateSurvivalTimeUI()
    {
        if (survivalTimeText != null)
        {
            // Format the time to show in minutes:seconds format
            int minutes = Mathf.FloorToInt(survivalTime / 60);
            int seconds = Mathf.FloorToInt(survivalTime % 60);
            survivalTimeText.text = string.Format("Digesting: {0:00}:{1:00}", minutes, seconds);
        }
    }
}
