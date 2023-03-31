using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SonicGameSaveSystem  
{
    private static string saveFilePath = Application.persistentDataPath + "/SonicGameData.json";

    public static void Save(SonicGameData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
    }

    public static SonicGameData Load()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            return JsonUtility.FromJson<SonicGameData>(json);
        }
        else
        {
            return null;
        }
    }
}
