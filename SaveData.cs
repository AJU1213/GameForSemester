using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Scripting;
using System.Collections;
using System.Collections.Generic;

[Preserve]
public static class SaveData
{
    private static readonly byte[] Key = { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF }; // 8-byte key for XOR encryption

    public static void SaveToJson(object data, string filePath)
    {
        string json = JsonUtility.ToJson(data);
        byte[] encryptedData = Encrypt(json);

        File.WriteAllBytes(filePath, encryptedData);
    }

    public static T LoadFromJson<T>(string filePath)
    {
        byte[] encryptedData = File.ReadAllBytes(filePath);
        string decryptedJson = Decrypt(encryptedData);

        return JsonUtility.FromJson<T>(decryptedJson);
    }

    private static byte[] Encrypt(string data)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(data);

        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] ^= Key[i % Key.Length];
        }

        return bytes;
    }

    private static string Decrypt(byte[] encryptedData)
    {
        byte[] bytes = new byte[encryptedData.Length];

        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = (byte)(encryptedData[i] ^ Key[i % Key.Length]);
        }

        return Encoding.UTF8.GetString(bytes);
    }
}
