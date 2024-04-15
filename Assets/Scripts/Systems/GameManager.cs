using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private List<Species> species;
    //[SerializeField] private Translations translation;
    [SerializeField] private Sprite earthIcon;

    [SerializeField] private Symbol[] goalMessage;

    private void Awake()
    {
        if (Instance == null)
            Initialize();
    }

    private void Initialize()
    {
        Instance = this;
        //Traits planet = new Traits(Traits.Shapes.PLANET, Traits.Colors.RED);
        //Traits star = new Traits(Traits.Shapes.STAR, Traits.Colors.RED);
        //Traits rocket = new Traits(Traits.Shapes.ROCKET, Traits.Colors.RED);
        //Traits[] message = new Traits[] { planet, star, rocket };
        //translation.changeInput(message);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.V))
    //    {
    //        Symbol[] testMessage = new Symbol[6];
    //        testMessage[0] = new Symbol(Symbol.Shapes.PLANET, Symbol.Colors.RED);
    //        testMessage[1] = new Symbol(Symbol.Shapes.COMET, Symbol.Colors.RED);
    //        testMessage[2] = new Symbol(Symbol.Shapes.COMET, Symbol.Colors.RED);
    //        testMessage[3] = new Symbol(Symbol.Shapes.COMET, Symbol.Colors.RED);
    //        testMessage[4] = new Symbol(Symbol.Shapes.COMET, Symbol.Colors.RED);
    //        testMessage[5] = new Symbol(Symbol.Shapes.COMET, Symbol.Colors.ORANGE);
    //        TransmitMessage(testMessage);
    //    }
    //}

    // For when someone sends a Message
    // This function is where big O times go to die
    public void TransmitMessage(Symbol[] message, Species caller)
    {
        TransmitBox.Instance.ConfirmButton.interactable = false;
        StartCoroutine(ProcessGlyphString(message, 1, true, null, caller));
    }

    private IEnumerator ProcessGlyphString(Symbol[] message, int substringLen, bool doChecks, Species responder, Species caller)
    {
        Symbol[] workingString = new Symbol[substringLen];
        for(int i = 0; i < substringLen; i++)
        {
            workingString[i] = message[i];
        }

        Dictionary<Species, int> hooksThisGlyph = new Dictionary<Species, int>();
        if (doChecks)
        {
            foreach (Species s in species)
            {
                int hookCount = s.CheckHooks(workingString);
                if (hookCount > 0)
                    hooksThisGlyph.Add(s, hookCount);
            }
        }

        // Spawn new Glyph within Message
        MessageLog.Instance.GetBottomMessage().ChangeSymbol(workingString[workingString.Length - 1], workingString.Length - 1);

        yield return new WaitForSeconds(doChecks ? 0.75f : 0.1f);

        while (hooksThisGlyph.Count > 0)
        {
            foreach (Species s in species)
            {
                if (hooksThisGlyph.ContainsKey(s))
                {
                    // Trigger the hook bubble anim
                    s.HooksThisCycle++;
                    s.ShowHookNotice();
                    if (s.HooksThisCycle >= 3)
                    {
                        // This is the species that's responding
                        responder = s;
                        s.ShowPortrait();
                        ClearSpeciesData(false);
                        break;
                    }
                    //Debug.Log("HOOK ON ITERATION " + substringLen + " FROM SPECIES " + s.SpeciesColor);
                    hooksThisGlyph[s] -= 1;
                    if (hooksThisGlyph[s] <= 0)
                        hooksThisGlyph.Remove(s);
                }
            }
            if (responder != null)
                break;
            yield return new WaitForSeconds(0.5f);
        }

        if (substringLen < message.Length)
            StartCoroutine(ProcessGlyphString(message, substringLen + 1, responder == null, responder, caller));
        else
        {
            TransmitBox.Instance.ConfirmButton.interactable = true;

            bool match = true;
            for (int i = 0; i < 6; i++)
            {
                if (message[i] != goalMessage[i])
                {
                    match = false;
                    break;
                }
            }

            if (match && caller != null)
            {
                caller.ShowShip();
            }

            // Actually send a message if responder is not null
            if (responder != null)
            {
                responder.RespondedThisCycle = true;
                responder.CraftResponse(message);
            }
            else
            {
                ClearSpeciesData(true);
            }
        }
            
    }

    public void ClearSpeciesData(bool deepClear)
    {
        foreach(Species s in species)
        {
            for (int i = 0; i < s.HookUsedFlags.Length; i++)
            {
                s.HookUsedFlags[i] = false;
            }
            s.HooksThisCycle = 0;
            if (deepClear)
            {
                s.RespondedThisCycle = false;
                s.HidePortrait();
            }
        }
    }

    public void Win()
    {

    }

    public void Lose()
    {

    }
}
