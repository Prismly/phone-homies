using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Translations/Mirror")]
public class MirrorTranslation : Translation
{
    public override Symbol[] ChangeInput(Symbol[] message)
    {
        Array.Reverse(message);
        return message;
    }
}
