using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Scripting;

[Serializable]

[Preserve]
public class SonicGameProgress
{
    public int score;
    public int rings;
    public int lives;
   
  
    public void SaveGame() 
    {
        // Save the player's progress to a JSON file
        SonicGameProgress progress = new SonicGameProgress();
        progress.score = 1000;
        progress.rings = 50;
        progress.lives = 3;
        SaveData.SaveToJson(progress, "sonicgameprogress.dat");
    }
    
    public void LoadGame()
    {
        // Load the player's progress from the JSON file
        SonicGameProgress loadedProgress = SaveData.LoadFromJson<SonicGameProgress>("sonicgameprogress.dat");
        Debug.Log("Loaded score: " + loadedProgress.score);
        Debug.Log("Loaded rings: " + loadedProgress.rings);
        Debug.Log("Loaded lives: " + loadedProgress.lives);
    }
}
