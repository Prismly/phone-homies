using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Translations/Color Flip")]
public class ColorFlipTranslation : Translation
{
    public override Symbol[] ChangeInput(Symbol[] message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            int character = (int)message[i].Color;
            switch (character)
            {
                case 0:
                    character = 5;
                    break;
                case 1:
                    character = 4;
                    break;
                case 2:
                    character = 3;
                    break;
                case 3:
                    character = 2;
                    break;
                case 4:
                    character = 1;
                    break;
                case 5:
                    character = 0;
                    break;
            }
            message[i].Color = (Symbol.Colors)character;
        }

        return message;
    }

}
