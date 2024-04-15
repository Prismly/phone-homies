using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageLog : MonoBehaviour
{
    public static MessageLog Instance;
    [SerializeField] private Sprite earthIcon;

    private void Awake()
    {
        if (Instance == null)
            Initialize();
    }

    private void Initialize()
    {
        Instance = this;
    }

    public void AddMessage()
    {

    }
}
