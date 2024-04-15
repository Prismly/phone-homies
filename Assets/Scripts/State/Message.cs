using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField] private GlyphUI[] glyphs;
    [SerializeField] private Image senderIcon;

    public void ChangeSymbol(Symbol symbol, int index)
    {
        if (index < 0 || index > 5)
            return;

        glyphs[index].SetTraits(symbol.Shape, symbol.Color);
        glyphs[index].SetVisible(true);
    }

    public void SetSenderIcon(Sprite icon)
    {
        senderIcon.sprite = icon;
    }
}
