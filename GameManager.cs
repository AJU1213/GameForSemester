using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    private void Start() 
    {
        LoadGame();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
    }

    // Save the player's progress
    public void SaveGame()
    {
        SonicGameData data = new SonicGameData();
        data.score = 1000;
        data.rings = 50;
        data.lives = 3;
        SonicGameSaveSystem.Save(data);
    }

    // Load the saved data
    public void LoadGame() 
    {
        SonicGameData savedData = SonicGameSaveSystem.Load();
        if (savedData != null)
        {
            // Update game state with saved data
            // For example:
            Debug.Log("Loading game...");
            Debug.Log("Score: " + savedData.score);
            Debug.Log("Rings: " + savedData.rings);
            Debug.Log("Lives: " + savedData.lives);
        }
        else
        {
            // No saved data found, start game with default values
            // For example:
            Debug.Log("Starting new game...");
        }
    }
}








