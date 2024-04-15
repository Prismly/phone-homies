using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Hook : ScriptableObject
{
    [SerializeField] public List<Traits> message;

    public abstract bool Consider(Traits[] message);
}
