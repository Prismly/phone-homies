using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseImage;
    [SerializeField] private GameObject pauseText;
    private bool isPaused = false;

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseImage.SetActive(true);
        pauseText.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseImage.SetActive(false);
        pauseText.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

}
