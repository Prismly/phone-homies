using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject colorBlindModeText;
    [SerializeField] private GameObject colorBlindModeIndicator;

    public void ColorBlindMode()
    {
        Settings.colorblind = !Settings.colorblind;
        if(Settings.colorblind)
        {
            colorBlindModeIndicator.SetActive(true);
        } else
        {
            colorBlindModeIndicator.SetActive(false);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
