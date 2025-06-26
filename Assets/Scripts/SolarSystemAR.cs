using UnityEngine;
using System.Collections.Generic;

public class SolarSystemAR : MonoBehaviour
{
    [Header("Ajustes de escala")]
    public float globalScaleFactor = 0.5f;

    [Header("Velocidad de rotación (sobre su eje)")]
    public float selfRotationSpeed = 30f;

    [Header("Velocidades de órbita (Mercurio a Plutón)")]
    public float[] orbitSpeeds = new float[] { 50f, 35f, 30f, 24f, 13f, 10f, 7f, 5f, 3f };

    private Dictionary<string, float> planetScales = new Dictionary<string, float>()
    {
        {"Sun", 1.09f},
        {"Mercury", 0.038f},
        {"Venus", 0.095f},
        {"Earth", 0.1f},
        {"Mars", 0.053f},
        {"Jupiter", 1.097f},
        {"Saturn", 0.914f},
        {"Uranus", 0.398f},
        {"Neptune", 0.387f}
    };

    private Transform sun;
    private List<Transform> planets = new List<Transform>();

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (planetScales.ContainsKey(child.name))
            {
                // Escalar cada cuerpo
                float scale = planetScales[child.name] * globalScaleFactor;
                child.localScale = Vector3.one * scale;

                if (child.name == "Sun")
                {
                    sun = child;
                }
                else
                {
                    planets.Add(child);
                }
            }
        }

        if (sun == null)
        {
            Debug.LogError("No se encontró el objeto 'Sun' entre los hijos.");
        }
    }

    void Update()
    {
        // Rotación sobre su eje
        foreach (Transform planet in planets)
        {
            planet.Rotate(Vector3.up * selfRotationSpeed * Time.deltaTime);
        }

        // Órbita alrededor del Sol
        for (int i = 0; i < planets.Count; i++)
        {
            float speed = (i < orbitSpeeds.Length) ? orbitSpeeds[i] : 10f;
            planets[i].RotateAround(sun.position, Vector3.up, speed * Time.deltaTime);
        }

        // El Sol también puede girar sobre su eje
        if (sun != null)
        {
            sun.Rotate(Vector3.up * (selfRotationSpeed / 2f) * Time.deltaTime);
        }
    }
}