using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class MinimumHook : Hooks
{
    [SerializeField] private Traits.Shapes shape;

    public override bool Consider(Traits[] message)
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
