using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Translations/Color Shift")]
public class ColorShiftTranslation : Translation
{
    [SerializeField] private int magnitude;

    public override Symbol[] ChangeInput(Symbol[] message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            int character = (int)message[i].Color;
            character += magnitude;
            character %= 6;
            message[i].Color = (Symbol.Colors)character;
        }

        return message;
    }
}
