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
    { "Sun", "The Sun is a giant star located at the center of our solar system. Its energy makes life on Earth possible." },
{ "Mercury", "Mercury is the closest planet to the Sun. It is small, rocky, and its surface is covered with craters." },
{ "Venus", "Venus is similar in size to Earth, but its dense and hot atmosphere makes it the hottest planet in the solar system." },
{ "Earth", "Earth is our home. It is the only known planet with life and has liquid water on its surface." },
{ "Mars", "Mars is known as the red planet due to the color of its surface. It may have hosted life in the past." },
{ "Jupiter", "Jupiter is the largest planet in the solar system. It has a Great Red Spot, which is a giant storm." },
{ "Saturn", "Saturn is famous for its spectacular rings, made of ice and rock. It is the second largest planet." },
{ "Uranus", "Uranus rotates on its side, as if it were rolling along its orbit. Its bluish-green color is due to methane gas in its atmosphere." },
{ "Neptune", "Neptune is a cold and very windy planet. It is the farthest from the Sun and has a beautiful deep blue color." }
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
