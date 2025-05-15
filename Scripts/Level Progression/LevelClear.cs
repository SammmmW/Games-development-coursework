using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClear : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private GameObject canvas;
    private int level;
    public int enemiesDefeated = 0;
    private int enemyGoal;
    // Start is called before the first frame update
    void Start()
    {
        level = VariableManager.Instance.level;
        setenemyGoal();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesDefeated == enemyGoal && player.activeSelf)
        {
            level = level + 1;
            VariableManager.Instance.level = level;
            enemiesDefeated = 0;
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
