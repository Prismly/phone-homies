using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hooks/Contains Shape")]
public class MinimumHook : Hook
{
    [SerializeField] private Symbol.Shapes shape;

    public override bool Consider(Symbol[] message)
    {
        for(int i = 0; i < message.Length; i++)
        {
            if (message[i].Shape == shape)
            {
                return true;
            }
        }

        return false;
    }

}
