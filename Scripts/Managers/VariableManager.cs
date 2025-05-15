using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableManager : MonoBehaviour
{
    public static VariableManager Instance;

    public float startingHealth = 1.0f; //needs to just be lower than 100
    public float currentHealth;
    public float speed = 1.0f;
    public float chargeTime;
    public float delay = 2.0f;
    public int level = 1;

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
