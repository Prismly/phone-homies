using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class MirrorTranslation : Translations
{
    public override Traits[] changeInput(Traits[] message)
    {
        Array.Reverse(message);
        return message;
    }
}
