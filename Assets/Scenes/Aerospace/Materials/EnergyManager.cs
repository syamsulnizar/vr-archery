using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    public TextMeshProUGUI energyText;
    public int energy = 10;

    public Volume volume;
    private Vignette vignette;
    public float intensity = 1;
    public float smoothness = 1;

    private void Start()
    {
        energy = 10;
        //vignette.intensity.value = intensity;
        //vignette.smoothness.value = smoothness;

    }

    private void Update()
    {
        energyText.text = "Energi saat ini : " + energy.ToString();

        volume.profile.TryGet(out vignette);
        {
            vignette.intensity.value = intensity; ;
            vignette.smoothness.value = smoothness;
        }

        if (energy == 10)
        {
            volume.profile.TryGet(out vignette);
            {
                intensity = 1;
                smoothness = 1;
            }
        }

        if (energy == 40)
        {
            volume.profile.TryGet(out vignette);
            {
                intensity = 1;
                smoothness = 0.5f;
            }
        }

        if (energy == 70)
        {
            volume.profile.TryGet(out vignette);
            {
                intensity = 0.5f;
                smoothness = 0.5f;
            }
        }

        if (energy == 100)
        {
            volume.profile.TryGet(out vignette);
            {
                intensity = 0;
                smoothness = 0;
            }
        }
    }

    public void AddEnergy()
    {
        energy += 30;
    }
}
