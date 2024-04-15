using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Hook : ScriptableObject
{
    public abstract bool Consider(Symbol[] message);
}
