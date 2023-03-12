using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum EnemyState {
        Attacking,
        Retreating
    }

    private EnemyState currentState = EnemyState.Attacking;

    // Use the 'new' keyword to hide the inherited Update() method
    new void Update()
    {
        switch (currentState) {
    case EnemyState.Attacking:
        if (PlayerHealth.GetInstance().health > 0)
        {
            // Attack the player
        }
        else
        {
            currentState = EnemyState.Retreating;
        }
        break;

    case EnemyState.Retreating:
        // Retreat
        break;
}

    }
}
