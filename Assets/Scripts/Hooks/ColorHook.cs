using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class ColorHook : Hooks
{
    [SerializeField] private Traits.Colors color;

    public override bool Consider(Traits[] message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            if (message[i].Color == color)
            {
                return true;
            }
        }

        return false;
    }
}
