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
        for (int i = 0; i < magnitude; i++)
        {
            List<Symbol> m = message.ToList();
            Symbol value = m[0];
            m.RemoveAt(0);
            m.Add(value);
            message = m.ToArray();
        }

        return message;
    }
}
