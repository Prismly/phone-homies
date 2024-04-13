using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //[SerializeField] List<Species> activeSpecies;

    public void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        
    }

    public void PlayerWin()
    {

    }
}
