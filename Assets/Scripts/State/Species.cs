using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Species : MonoBehaviour
{
    [SerializeField] public List<Translation> translations;
    [SerializeField] public List<Hook> hooks;

    public bool ConsiderMessage()
    {
        return true;
    }

    public Traits[] ReceiveMessage()
    {
        return null;
    }
}
