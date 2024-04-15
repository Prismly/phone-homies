using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private List<Species> species;
    [SerializeField] private Translations translation;

    private void Awake()
    {
        if (Instance == null)
            Initialize();
    }

    private void Initialize()
    {
        Instance = this;
        Traits planet = new Traits(Traits.Shapes.PLANET, Traits.Colors.RED);
        Traits star = new Traits(Traits.Shapes.STAR, Traits.Colors.RED);
        Traits rocket = new Traits(Traits.Shapes.ROCKET, Traits.Colors.RED);
        Traits[] message = new Traits[] { planet, star, rocket };
        translation.changeInput(message);
    }

    public void TransmitMessage(Glyph[] message)
    {
        foreach(Species s in species)
        {
            
        }
    }

    public void Win()
    {

    }

    public void Lose()
    {

    }
}
