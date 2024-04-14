using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Species : MonoBehaviour
{
    [SerializeField] public int priority;
    [SerializeField] public List<Translations> translations;

    public bool ConsiderMessage()
    {
        return true;
    }

    public Traits[] ReceiveMessage()
    {
        return null;
    }
}
