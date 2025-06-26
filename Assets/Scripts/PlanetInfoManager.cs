using System.Collections.Generic;
using UnityEngine;

public class PlanetInfoManager : MonoBehaviour
{
    public PlanetInfoUI ui;

    // Lista de planetas incluyendo el Sol primero
    private List<string> planetNames = new List<string> {
        "Sun", "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"
    };

    private Dictionary<string, string> planetDescriptions = new Dictionary<string, string>()
{
    { "Sun", "El Sol es una estrella gigante que se encuentra en el centro de nuestro sistema solar. Su energía hace posible la vida en la Tierra." },
    { "Mercury", "Mercurio es el planeta más cercano al Sol. Es pequeño, rocoso y su superficie está llena de cráteres." },
    { "Venus", "Venus es similar en tamaño a la Tierra, pero su atmósfera densa y caliente lo convierte en el planeta más cálido del sistema solar." },
    { "Earth", "La Tierra es nuestro hogar. Es el único planeta conocido con vida y posee agua en estado líquido." },
    { "Mars", "Marte es conocido como el planeta rojo por el color de su superficie. Podría haber albergado vida en el pasado." },
    { "Jupiter", "Júpiter es el planeta más grande del sistema solar. Tiene una gran mancha roja que es una tormenta gigante." },
    { "Saturn", "Saturno es famoso por sus espectaculares anillos, compuestos por hielo y roca. Es el segundo planeta más grande." },
    { "Uranus", "Urano gira de lado, como si rodara en su órbita. Su color azul verdoso se debe al gas metano en su atmósfera." },
    { "Neptune", "Neptuno es un planeta frío y muy ventoso. Es el más lejano del Sol y tiene un hermoso color azul intenso." }
    };


    private int currentIndex = 3; // Iniciamos en el Sol (índice 0)

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        // Cambiar planeta con flechas izquierda y derecha

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex = (currentIndex + 1) % planetNames.Count;
            UpdateUI();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex--;
            if (currentIndex < 0) currentIndex = planetNames.Count - 1;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        string name = planetNames[currentIndex];
        string info = planetDescriptions.ContainsKey(name) ? planetDescriptions[name] : "No info available.";

        if (ui != null)
        {
            ui.UpdatePlanetInfo(name, info);
        }
    }

    public void NextPlanet()
    {
        currentIndex = (currentIndex + 1) % planetNames.Count;
        UpdateUI();
    }

    public void PreviousPlanet()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = planetNames.Count - 1;
        UpdateUI();
    }
}
