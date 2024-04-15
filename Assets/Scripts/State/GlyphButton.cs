using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlyphButton : MonoBehaviour
{
    [SerializeField] private Traits.Shapes shape;

    public void OnClick()
    {
        TransmitBox.Instance.AppendGlyph(shape, TransmitBox.Instance.ActiveColor);
    }
}