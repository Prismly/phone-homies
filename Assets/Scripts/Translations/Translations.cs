using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public abstract class Translations : ScriptableObject
{
    public abstract Traits[] changeInput(Traits[] message);
}
