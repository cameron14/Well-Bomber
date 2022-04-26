using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadLevel1()
    {
        SceneManager.LoadScene("level1");
    }

    public void loadLevel2()
    {
        SceneManager.LoadScene("level2");
    }

    public void loadLevel3()
    {
        SceneManager.LoadScene("level3");
    }

    public void loadLevel4()
    {
        SceneManager.LoadScene("level4");
    }

    public void loadLevel5()
    {
        SceneManager.LoadScene("level5");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit.");
    }

    public void Controls()
    {
        SceneManager.LoadScene("controlsScreen");
    }

    public void mainMenuScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
