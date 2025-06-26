using UnityEngine;
using TMPro;

public class PlanetInfoUI : MonoBehaviour
{
    public TextMeshProUGUI planetNameText;
    public TextMeshProUGUI planetInfoText;

    public void UpdatePlanetInfo(string name, string info)
    {
        if (planetNameText != null)
            planetNameText.text = name;

        if (planetInfoText != null)
            planetInfoText.text = info;
    }
}
