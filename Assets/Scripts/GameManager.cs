using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] List<Species> species;

    private void Awake()
    {
        if (Instance == null)
            Initialize();
    }

    private void Initialize()
    {
        Instance = this;
    }

    public void TransmitMessage(Glyph[] message)
    {
        foreach(Species s in species)
        {
            
        }
    }

    public void Win()
    {

    }

    public void Lose()
    {

    }
}
