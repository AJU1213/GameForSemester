using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    private PlayerHealth Instance;

    // Reference to UI text displaying player health
    public Text healthText;

    public static PlayerHealth GetInstance()
    {
       if (Instance == null)
        {
            Instance = new PlayerHealth();
        } 
        return Instance;
    }

    private void Awake()
    {
        // Ensure there is only one instance of PlayerHealth
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Update UI text with current health value
        healthText.text = "Health: " + health.ToString();
    }
}

