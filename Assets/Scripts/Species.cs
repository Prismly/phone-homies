using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Species : MonoBehaviour
{

    public enum HookResponses
    {
        RESPOND,
        PASS,
        DROP
    }

    public HookResponses ConsiderMessage()
    {
        return HookResponses.PASS;
    }

    public Traits[] ReceiveMessage()
    {
        return null;
    }
}
