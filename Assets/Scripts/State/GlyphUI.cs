using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlyphUI : MonoBehaviour
{
    [SerializeField] private Traits symbol;

    [SerializeField] private Image shapeImg;
    [SerializeField] private Image outlineImg;
    [SerializeField] private Image patternImg;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SetTraits(Traits.Shapes.ATOM, Traits.Colors.RED);
        if (Input.GetKeyDown(KeyCode.B))
            SetTraits(Traits.Shapes.PLANET, Traits.Colors.ORANGE);
        if (Input.GetKeyDown(KeyCode.C))
            SetTraits(Traits.Shapes.PLANET, Traits.Colors.YELLOW);
        if (Input.GetKeyDown(KeyCode.D))
            SetTraits(Traits.Shapes.FACE, Traits.Colors.GREEN);
        if (Input.GetKeyDown(KeyCode.E))
            SetTraits(Traits.Shapes.MOLECULE, Traits.Colors.BLUE);
        if (Input.GetKeyDown(KeyCode.F))
            SetTraits(Traits.Shapes.ROCKET, Traits.Colors.PURPLE);
    }

    public void SetTraits(Traits.Shapes newShape, Traits.Colors newColor)
    {
        symbol.Shape = newShape;
        symbol.Color = newColor;

        ShapeData shapeData = GlyphAtlas.Instance.ShapeDatas[symbol.Shape];
        shapeImg.sprite = shapeData.ShapeSprite;
        outlineImg.sprite = shapeData.OutlineSprite;

        ColorData colorData = GlyphAtlas.Instance.ColorDatas[symbol.Color];
        shapeImg.color = colorData.LineColor;
        outlineImg.color = colorData.OutlineColor;
        patternImg.sprite = colorData.ColorblindPattern;
    }

    public Traits.Shapes GetShape()
    {
        return symbol.Shape;
    }

    public Traits.Colors GetColor()
    {
        return symbol.Color;
    }
}
