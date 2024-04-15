using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    [SerializeField] private Traits.Colors color;

    public void OnClick()
    {
        TransmitBox.Instance.ChangeActiveColor(color);
    }
}
