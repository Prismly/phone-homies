using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hooks/Contains Color")]
public class ColorHook : Hook
{
    [SerializeField] private Symbol.Colors color;

    public override bool Consider(Symbol[] message)
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
