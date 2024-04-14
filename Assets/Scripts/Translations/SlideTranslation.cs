using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu]

public class SlideTranslation : Translations
{
    [SerializeField] private int magnitude;
    [SerializeField] private Traits.Shapes shape;

    public override Traits[] changeInput(Traits[] message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            if (message[i].Shape == shape)
            {
                List<Traits> m = message.ToList();
                Traits value = m[i];
                m.RemoveAt(i);
                m.Insert((i - magnitude) % message.Length, value);
                message = m.ToArray();
            }
        }

        return message;
    }
}
