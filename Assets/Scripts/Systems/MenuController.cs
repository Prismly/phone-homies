using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LaunchGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
