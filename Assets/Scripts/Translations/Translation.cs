using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Translation : ScriptableObject
{
    public abstract Symbol[] ChangeInput(Symbol[] message);
}
