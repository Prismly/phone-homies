using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public abstract class Hooks : ScriptableObject
{
    [SerializeField] public List<Traits> message;

    public abstract bool Consider(Traits[] message);
}
