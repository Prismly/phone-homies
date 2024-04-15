using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu]

public class SlideTranslation : Translations
{
    [SerializeField] private int magnitude;

    public override Traits[] changeInput(Traits[] message)
    {
        for (int i = 0; i < magnitude; i++)
        {
            List<Traits> m = message.ToList();
            Traits value = m[0];
            m.RemoveAt(0);
            m.Add(value);
            message = m.ToArray();
        }

        return message;
    }
}
