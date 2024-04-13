using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShapeData : ScriptableObject
{
    [SerializeField] public Sprite ShapeSprite;
    [SerializeField] public Sprite OutlineSprite;
}
