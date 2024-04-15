using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class PairFlipTranslation : Translations
{
    public override Traits[] changeInput(Traits[] message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            int character = (int)message[i].Shape;
            switch (character)
            {
                case 0:
                    character = 1;
                    break;
                case 1:
                    character = 0;
                    break;
                case 2:
                    character = 3;
                    break;
                case 3:
                    character = 2;
                    break;
                case 4:
                    character = 5;
                    break;
                case 5:
                    character = 4;
                    break;
                case 6:
                    character = 7;
                    break;
                case 7:
                    character = 6;
                    break;
            }
            message[i].Shape = (Traits.Shapes)character;
        }

        return message;
    }

}
