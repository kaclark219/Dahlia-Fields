using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    public Light2D DayLight;
    public Gradient DayLightGradient;

    public Light2D NightLight;
    public Gradient NightLightGradient;

    private int currEnergy = 50;

    public void ResetLight()
    {
        float ratio = 0.0f;
        DayLight.color = DayLightGradient.Evaluate(ratio);
        NightLight.color = NightLightGradient.Evaluate(ratio);

        transform.rotation = Quaternion.Euler(0, 0, 360.0f * ratio);
        currEnergy = 50;
    }

    public void UpdateLight(int energy)
    {
        StartCoroutine(IncrementLight(energy));
    }

    IEnumerator IncrementLight(int energy)
    {
        while (currEnergy != energy)
        {
            float ratio = (50 - currEnergy) / 50.0f;
            DayLight.color = DayLightGradient.Evaluate(ratio);
            NightLight.color = NightLightGradient.Evaluate(ratio);

            transform.rotation = Quaternion.Euler(0, 0, 360.0f * ratio);
            currEnergy--;

            yield return new WaitForSeconds(0.1f);
        }
        currEnergy = energy;
    }
}

