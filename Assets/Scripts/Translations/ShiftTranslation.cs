using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Translations/Shift")]
public class ShiftTranslation : Translation
{
    [SerializeField] private int magnitude;

    public override Symbol[] changeInput(Symbol[] message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            int character = (int)message[i].Shape;
            character += magnitude;
            character %= 8;
            message[i].Shape = (Symbol.Shapes)character;
        }

        return message;
    }
}
