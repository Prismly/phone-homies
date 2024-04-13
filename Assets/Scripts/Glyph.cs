using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glyph : MonoBehaviour
{
    [SerializeField] private Shapes shape;
    [SerializeField] private Colors color;

    [SerializeField] private SpriteRenderer shapeRend;
    [SerializeField] private SpriteRenderer outlineRend;
    [SerializeField] private SpriteRenderer patternRend;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SetTraits(Shapes.ATOM, Colors.RED);
        if (Input.GetKeyDown(KeyCode.B))
            SetTraits(Shapes.PLANET, Colors.ORANGE);
        if (Input.GetKeyDown(KeyCode.C))
            SetTraits(Shapes.PLANET, Colors.YELLOW);
        if (Input.GetKeyDown(KeyCode.D))
            SetTraits(Shapes.FACE, Colors.GREEN);
        if (Input.GetKeyDown(KeyCode.E))
            SetTraits(Shapes.MOLECULE, Colors.BLUE);
        if (Input.GetKeyDown(KeyCode.F))
            SetTraits(Shapes.ROCKET, Colors.PURPLE);
    }

    public enum Shapes
    {
        PLANET,
        STAR,
        ROCKET,
        ATOM,
        NEBULA,
        MOLECULE,
        COMET,
        FACE
    }
    public enum Colors
    {
        RED,
        ORANGE,
        YELLOW,
        GREEN,
        BLUE,
        PURPLE
    }

    private void SetTraits(Shapes newShape, Colors newColor)
    {
        shape = newShape;
        color = newColor;

        ShapeData shapeData = GlyphAtlas.Instance.ShapeDatas[shape];
        shapeRend.sprite = shapeData.ShapeSprite;
        outlineRend.sprite = shapeData.OutlineSprite;

        ColorData colorData = GlyphAtlas.Instance.ColorDatas[color];
        shapeRend.color = colorData.LineColor;
        outlineRend.color = colorData.OutlineColor;
        patternRend.sprite = colorData.ColorblindPattern;
    }
}
