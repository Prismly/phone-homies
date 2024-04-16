using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hooks/Does Not Contain Color")]
public class DoesNotContainColorHook : Hook
{
    [SerializeField] private Symbol.Colors color;

    public override bool Consider(Symbol[] message)
    {
        // We only know for sure when all six glyphs are in the message.
        if (message.Length < 6)
            return false;

        for (int i = 0; i < message.Length; i++)
        {
            if (message[i].Color != color)
            {
                return true;
            }
        }

        return false;
    }
}
