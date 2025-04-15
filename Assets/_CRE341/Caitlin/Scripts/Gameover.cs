using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Gameover : MonoBehaviour
{
    [Header("Levels To Load")]
    public string Menu;
    public string Level_1;

    public void MenuScreen()
     {
        SceneManager.LoadScene("Menu");
    }

public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level_1");
    }
}
