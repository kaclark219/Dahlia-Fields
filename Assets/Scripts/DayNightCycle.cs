using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
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

        Vector3 point = DayLight.transform.position;
        float angle = 0.0f;
        NightLight.transform.RotateAround(point, Vector3.forward, angle);
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
            float ratio = ((50 - currEnergy) / 50.0f);
            DayLight.color = DayLightGradient.Evaluate(ratio);
            NightLight.color = NightLightGradient.Evaluate(ratio);

            Vector3 point = DayLight.transform.position;
            //float angle = 180 * ratio;
            //NightLight.transform.RotateAround(point, Vector3.forward, angle);
            currEnergy--;

            yield return new WaitForSeconds(0.1f);
        }
        currEnergy = energy;
    }
}

