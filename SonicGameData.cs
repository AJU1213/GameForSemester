using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class SonicGameData 
{
    public int score;
    public int rings;
    public int lives;
    public string playerName;
    public int playerHealth;
    
    // Save the player's progress
    public void SaveGame()
    {
        SonicGameData data = new SonicGameData();
        data.score = score;
        data.rings = rings;
        data.lives = lives;
        data.playerName = playerName;
        data.playerHealth = playerHealth;
        SonicGameSaveSystem.Save(data);
    }

    // Load the saved data
    public void LoadGame() 
    {
        SonicGameData savedData = SonicGameSaveSystem.Load();
        if (savedData != null)
        {
            // Update game state with saved data
            playerName = savedData.playerName;
            rings = savedData.rings;
            score = savedData.score;
            lives = savedData.lives;
            playerHealth = savedData.playerHealth;
        }
        else
        {
            // No saved data found, start game with default values
            playerName = "Sonic";
            playerHealth = 100;
            score = 0;
            lives = 3;
            rings = 0;
        }
    }
}
