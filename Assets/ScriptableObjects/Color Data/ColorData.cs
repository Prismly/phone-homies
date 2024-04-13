using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorData : ScriptableObject
{
    [SerializeField] public Color LineColor;
    [SerializeField] public Color OutlineColor;
    [SerializeField] public Sprite ColorblindPattern;
}
