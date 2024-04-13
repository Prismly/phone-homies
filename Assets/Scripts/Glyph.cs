using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glyph : MonoBehaviour
{
    [SerializeField] private Traits symbol;

    [SerializeField] private SpriteRenderer shapeRend;
    [SerializeField] private SpriteRenderer outlineRend;
    [SerializeField] private SpriteRenderer patternRend;

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

    private void SetTraits(Traits.Shapes newShape, Traits.Colors newColor)
    {
        symbol.Shape = newShape;
        symbol.Color = newColor;

        ShapeData shapeData = GlyphAtlas.Instance.ShapeDatas[symbol.Shape];
        shapeRend.sprite = shapeData.ShapeSprite;
        outlineRend.sprite = shapeData.OutlineSprite;

        ColorData colorData = GlyphAtlas.Instance.ColorDatas[symbol.Color];
        shapeRend.color = colorData.LineColor;
        outlineRend.color = colorData.OutlineColor;
        patternRend.sprite = colorData.ColorblindPattern;
    }
}
