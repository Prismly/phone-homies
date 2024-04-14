using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransmitBox : MonoBehaviour
{
    private Traits.Colors activeColor = Traits.Colors.RED;
    [SerializeField] private GlyphUI[] glyphButtons;

    private void Start()
    {
        UpdateButtonIcons();
    }

    public void ChangeActiveColor(Traits.Colors newColor)
    {
        activeColor = newColor;
    }

    private void UpdateButtonIcons()
    { 
        foreach (GlyphUI glyph in glyphButtons)
            glyph.SetTraits(glyph.GetShape(), activeColor);
    }
}
