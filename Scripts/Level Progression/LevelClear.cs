using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelClear : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private GameObject canvas;
    private int level;
    public int enemiesDefeated = 0;
    private int enemyGoal;
    [SerializeField] private TMP_Text counter;
    // Start is called before the first frame update
    void Start()
    {
        level = VariableManager.Instance.level;
        VariableManager.Instance.enemiesDefeated = enemiesDefeated;
        setenemyGoal();
        counter.text = "Enemies defeated: " + enemiesDefeated.ToString() + "/" + enemyGoal.ToString();
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
                VariableManager.Instance.enemyGoal = enemyGoal;
                break;
            case 2:
                enemyGoal = 3;
                VariableManager.Instance.enemyGoal = enemyGoal;
                break;
            case 3:
                enemyGoal = 7;
                VariableManager.Instance.enemyGoal = enemyGoal;
                break;
            case 4:
                enemyGoal = 11;
                VariableManager.Instance.enemyGoal = enemyGoal;
                break;
        }
    }
    public void trackEnemiesDefeated()
    {
        enemiesDefeated++;
        VariableManager.Instance.enemiesDefeated = enemiesDefeated;
        counter.text = "Enemies defeated: " + enemiesDefeated.ToString() + "/" + enemyGoal.ToString();
    }
}
