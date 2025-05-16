using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject player;
    public void openGame()
    {
        menu.SetActive(false);
        player.SetActive(true);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void resetGame()
    {
        VariableManager.Instance.level = 1;
        SceneManager.LoadScene(0);
    }
}
