using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TransmitBox : MonoBehaviour
{
    public static TransmitBox Instance;
    private void Awake()
    {
        if (Instance == null)
            Initialize();
    }

    private void Initialize()
    {
        Instance = this;
    }

    public Traits.Colors ActiveColor = Traits.Colors.RED;
    [SerializeField] private GlyphUI[] glyphButtonIcons;
    [SerializeField] private GameObject glyphUIPref;
    [SerializeField] private RectTransform glyphArray;
    List<GlyphUI> bufferedMessage = new List<GlyphUI>();

    private void Start()
    {
        UpdateButtonIcons();
    }

    public void ChangeActiveColor(Traits.Colors newColor)
    {
        ActiveColor = newColor;
        UpdateButtonIcons();
    }

    private void UpdateButtonIcons()
    { 
        foreach (GlyphUI glyph in glyphButtonIcons)
            glyph.SetTraits(glyph.GetShape(), ActiveColor);
    }

    public void BackspaceGlyph()
    {
        if (bufferedMessage.Count <= 0)
            return;

        Destroy(bufferedMessage.Last().gameObject);
        bufferedMessage.RemoveAt(bufferedMessage.Count - 1);
    }

    public bool AppendGlyph(Traits.Shapes shape, Traits.Colors color)
    {
        if (bufferedMessage.Count >= 6)
            return false;

        GameObject newGlyphUIObj = Instantiate(glyphUIPref);
        newGlyphUIObj.transform.SetParent(glyphArray);
        GlyphUI newGlyphUI = newGlyphUIObj.GetComponent<GlyphUI>();
        newGlyphUI.SetTraits(shape, color);
        RectTransform newGlyphUIRect = newGlyphUIObj.GetComponent<RectTransform>();
        newGlyphUIRect.localScale = Vector3.one;
        bufferedMessage.Add(newGlyphUI);

        return true;
    }
}
