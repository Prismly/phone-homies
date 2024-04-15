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
    [SerializeField] private SpriteRenderer shipRend;
    [SerializeField] public Sprite MessageIcon;
    [SerializeField] private SpriteRenderer hookNoticeBubble;
    [SerializeField] private Animator hookNoticeFX;
    [SerializeField] private Sprite[] hookNoticeBubbleSprites;
    [SerializeField] private KeyCode debugKey;

    public bool[] HookUsedFlags;
    public int HooksThisCycle = 0;
    public bool RespondedThisCycle = false;

    private void Start()
    {
        shipRend.color = Color.clear;
        HookUsedFlags = new bool[Hooks.Count];
    }

    private void Update()
    {
    }

    public int CheckHooks(Symbol[] message)
    {
        if (RespondedThisCycle)
            return 0;

        int hooksTriggered = 0;
        for(int h = 0; h < Hooks.Count; h++)
        {
            if (!HookUsedFlags[h])
            {
                bool result = Hooks[h].Consider(message);
                if (result)
                {
                    hooksTriggered++;
                    HookUsedFlags[h] = true;
                }
            }
        }

        return hooksTriggered;
    }

    public void ShowHookNotice()
    {
        if (HooksThisCycle <= 3)
            StartCoroutine(ShowHideHookBubble());
    }

    private IEnumerator ShowHideHookBubble()
    {
        hookNoticeFX.SetTrigger("Activate");
        hookNoticeBubble.sprite = hookNoticeBubbleSprites[HooksThisCycle - 1];
        yield return new WaitForSeconds(0.4f);
        hookNoticeBubble.sprite = null;
    }

    public void CraftResponse(Symbol[] input)
    {
        Symbol[] translated = input;
        foreach (Translation t in Translations)
            translated = t.ChangeInput(translated);
        MessageLog.Instance.AddMessage(this);
        GameManager.Instance.TransmitMessage(translated, this);
    }

    public void ShowPortrait()
    {
        // To prevent pop-in on startup, face sprite is activated the first time it is needed
        faceSprite.color = Color.white;
        portraitBubble.SetBool("Active", true);
    }
    
    public void HidePortrait()
    {
        faceSprite.color = Color.clear;
        portraitBubble.SetBool("Active", false);
    }

    public void ShowShip()
    {
        shipRend.color = Color.white;
    }
}
