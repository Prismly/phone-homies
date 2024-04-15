using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpriteMasker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rendToMask;
    private SpriteMask mask;

    [SerializeField] private List<SpritePair> conversionList;
    private Dictionary<Sprite, Sprite> conversions;
    private Sprite lastSeenSprite = null;

    [Serializable]
    private class SpritePair
    {
        [SerializeField] public Sprite In;
        [SerializeField] public Sprite Out;
    }

    private void Awake()
    {
        conversions = new Dictionary<Sprite, Sprite>();
        mask = GetComponent<SpriteMask>();
        foreach (SpritePair pair in conversionList)
            conversions.Add(pair.In, pair.Out);
    }

    private void Start()
    {
        lastSeenSprite = rendToMask.sprite;
    }

    private void Update()
    {
        if (lastSeenSprite != rendToMask.sprite)
        {
            Sprite convertedSprite = null;
            conversions.TryGetValue(rendToMask.sprite, out convertedSprite);
            if (convertedSprite != null)
                mask.sprite = conversions[rendToMask.sprite];
            lastSeenSprite = rendToMask.sprite;
        }
    }
}
