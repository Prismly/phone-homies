using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Translations/Slide")]
public class SlideTranslation : Translation
{
    [SerializeField] private int magnitude;

    public override Symbol[] changeInput(Symbol[] message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            List<Symbol> m = message.ToList();
            Symbol value = m[i];
            m.RemoveAt(i);
            m.Insert((i - magnitude) % message.Length, value);
            message = m.ToArray();
        }

        return message;
    }
}
