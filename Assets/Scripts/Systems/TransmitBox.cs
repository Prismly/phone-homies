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

    public Symbol.Colors ActiveColor = Symbol.Colors.RED;
    [SerializeField] private GlyphUI[] glyphButtonIcons;
    [SerializeField] private GameObject glyphUIPref;
    [SerializeField] private RectTransform glyphArray;
    List<GlyphUI> bufferedMessage = new List<GlyphUI>();

    private void Start()
    {
        UpdateButtonIcons();
    }

    public void ChangeActiveColor(Symbol.Colors newColor)
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

    public bool AppendGlyph(Symbol.Shapes shape, Symbol.Colors color)
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

    public void SendMessage()
    {

    }
}
