using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Translations/Mirror")]
public class MirrorTranslation : Translation
{
    public override Traits[] changeInput(Traits[] message)
    {
        Array.Reverse(message);
        return message;
    }
}
