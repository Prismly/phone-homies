using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Species : MonoBehaviour
{
    [SerializeField] public Symbol.Colors SpeciesColor;

    [SerializeField] public List<Translation> Translations;
    [SerializeField] public List<Hook> Hooks;

    [SerializeField] private SpriteRenderer faceSprite;
    [SerializeField] private Animator portraitBubble;
    [SerializeField] private SpriteRenderer shipSprite;
    [SerializeField] public Sprite MessageIcon;
    [SerializeField] private KeyCode debugKey;

    private bool[] hookUsedFlags;
    public int HooksThisCycle = 0;
    public bool RespondedThisCycle = false;

    private void Start()
    {
        shipSprite.color = Color.clear;
        hookUsedFlags = new bool[Hooks.Count];
    }

    private void Update()
    {
        if (Input.GetKeyDown(debugKey))
        {
            SendMessage();
        }
    }

    public int CheckHooks(Symbol[] message)
    {
        int hooksTriggered = 0;
        for(int h = 0; h < Hooks.Count; h++)
        {
            if (!hookUsedFlags[h])
            {
                bool result = Hooks[h].Consider(message);
                if (result)
                {
                    hooksTriggered++;
                    hookUsedFlags[h] = true;
                }
            }
        }

        foreach (Hook hook in Hooks)
        {
            
        }
        return hooksTriggered;
    }

    public Symbol[] ReceiveMessage()
    {
        return null;
    }

    public void SendMessage()
    {
        // To prevent pop-in on startup, face sprite is activated the first time it is needed
        faceSprite.color = Color.white;
        portraitBubble.SetBool("Active", true);
        StartCoroutine(Yap());
    }

    private IEnumerator Yap()
    {
        yield return new WaitForSeconds(2);
        portraitBubble.SetBool("Active", false);
    }
}
