using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu]

public class ReverseSlideTranslation : Translations
{
    [SerializeField] private int magnitude;

    public override Traits[] changeInput(Traits[] message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            List<Traits> m = message.ToList();
            Traits value = m[i];
            m.RemoveAt(i);
            m.Insert((i + magnitude) % message.Length, value);
            message = m.ToArray();
        }

        return message;
    }
}