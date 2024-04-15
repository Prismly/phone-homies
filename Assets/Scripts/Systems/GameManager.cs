using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private List<Species> species;
    [SerializeField] private Sprite earthIcon;

    private void Awake()
    {
        if (Instance == null)
            Initialize();
    }

    private void Initialize()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Symbol[] testMessage = new Symbol[6];
            testMessage[0] = new Symbol(Symbol.Shapes.PLANET, Symbol.Colors.RED);
            testMessage[1] = new Symbol(Symbol.Shapes.COMET, Symbol.Colors.RED);
            testMessage[2] = new Symbol(Symbol.Shapes.COMET, Symbol.Colors.RED);
            testMessage[3] = new Symbol(Symbol.Shapes.COMET, Symbol.Colors.RED);
            testMessage[4] = new Symbol(Symbol.Shapes.COMET, Symbol.Colors.RED);
            testMessage[5] = new Symbol(Symbol.Shapes.COMET, Symbol.Colors.ORANGE);
            TransmitMessage(testMessage, species[0]);
        }
    }

    // For when the player sends a Message
    public void TransmitMessage(Symbol[] message)
    {

    }

    // For when an alien sends a Message
    // This function is where big O times go to die
    public void TransmitMessage(Symbol[] message, Species sender)
    {
        StartCoroutine(ProcessGlyphString(message, 1));
    }

    private IEnumerator ProcessGlyphString(Symbol[] message, int substringLen)
    {
        Symbol[] workingString = new Symbol[substringLen];
        for(int i = 0; i < substringLen; i++)
        {
            workingString[i] = message[i];
        }

        Dictionary<Species, int> hooksThisGlyph = new Dictionary<Species, int>();

        foreach (Species s in species)
        {
            int hookCount = s.CheckHooks(workingString);
            if (hookCount > 0)
                hooksThisGlyph.Add(s, hookCount);
        }

        // Spawn new Glyph within Message

        yield return new WaitForSeconds(1);

        while (hooksThisGlyph.Count > 0)
        {
            foreach (Species s in species)
            {
                if (hooksThisGlyph.ContainsKey(s))
                {
                    // Trigger the hook bubble anim
                    Debug.Log("HOOK ON ITERATION " + substringLen + " FROM SPECIES " + s.SpeciesColor);
                    hooksThisGlyph[s] -= 1;
                    if (hooksThisGlyph[s] <= 0)
                        hooksThisGlyph.Remove(s);
                }
            }
            yield return new WaitForSeconds(1);
        }

        if (substringLen < message.Length)
            StartCoroutine(ProcessGlyphString(message, substringLen + 1));
    }

    public void Win()
    {

    }

    public void Lose()
    {

    }
}
