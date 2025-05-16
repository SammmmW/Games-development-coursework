using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableManager : MonoBehaviour
{
    public static VariableManager Instance;

    public float startingHealth; 
    public float currentHealth;
    public float speed;
    public float chargeTime;
    public float delay;
    public int level = 1;
    public int enemiesDefeated = 0;
    public int enemyGoal = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
