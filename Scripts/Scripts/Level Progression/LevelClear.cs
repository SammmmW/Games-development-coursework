using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClear : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private GameObject canvas;
    private int level = 1;
    public int enemiesDefeated = 0;
    private int enemyGoal;
    // Start is called before the first frame update
    void Start()
    {
        setenemyGoal();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesDefeated == enemyGoal && player.activeSelf)
        {
            level = level++;
            enemiesDefeated = 0;
            setenemyGoal();
            canvas.SetActive(true);
        }
    }

    void setenemyGoal()
    {
        switch (level)
        {
            case 1:
                enemyGoal = 2;
                break;
            case 2:
                enemyGoal = 3;
                break;
        }
    }
    public void trackEnemiesDefeated()
    {
        enemiesDefeated++;
    }
}
