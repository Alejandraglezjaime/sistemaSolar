using System.Collections.Generic;
using UnityEngine;

public class MultiTargetsVuforia : MonoBehaviour
{
    [SerializeField] private GameObject startModel;             // Planeta inicial (ej: Tierra)
    [SerializeField] private List<AudioClip> planetAudios;      // Lista de audios para cada planeta

    private int modelsCount;
    private int indexCurrentModel;
    private bool isFirstDisplay = true;                         // Solo para evitar audio al inicio
    private AudioSource audioSource;

    void Start()
    {
        modelsCount = transform.childCount;
        indexCurrentModel = startModel.transform.GetSiblingIndex();

        // Activar solo el modelo inicial
        for (int i = 0; i < modelsCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == indexCurrentModel);
        }

        // Inicializar el AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;  // Sonido continuo mientras el planeta esté activo

        // No reproducir audio al iniciar (solo Sistema Solar)
    }

    public void ChangeARModel(int index)
    {
        // Apagar el modelo actual
        transform.GetChild(indexCurrentModel).gameObject.SetActive(false);

        // Calcular nuevo índice
        int newIndex = indexCurrentModel + index;
        if (newIndex < 0)
            newIndex = modelsCount - 1;
        else if (newIndex >= modelsCount)
            newIndex = 0;

        // Activar el nuevo modelo
        transform.GetChild(newIndex).gameObject.SetActive(true);
        indexCurrentModel = newIndex;

        // Ya no es el primer despliegue
        isFirstDisplay = false;

        // Reproducir el audio del nuevo planeta
        PlayPlanetAudio();
    }

    private void PlayPlanetAudio()
    {
        // Solo si no es el primer despliegue y el índice es válido
        if (!isFirstDisplay && planetAudios != null && indexCurrentModel < planetAudios.Count && planetAudios[indexCurrentModel] != null)
        {
            audioSource.Stop();
            audioSource.clip = planetAudios[indexCurrentModel];
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
