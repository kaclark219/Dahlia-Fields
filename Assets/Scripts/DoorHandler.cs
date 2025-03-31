using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

public class DoorHandler : InteractableObj
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject location;
    [SerializeField] public Canvas baseui; 
    [SerializeField] public Image doorTransition;
    float alpha = 0f; 

    public override void Awake()
    {
        base.Awake();
        player = GameObject.Find("Player");
    }

    public override void Start()
    {
        base.Start();
        baseui.enabled = false; 
    }

    public override void OnInteract()
    {
        base.OnInteract();
        StartCoroutine(FadeAndTeleport());
    }

    private IEnumerator FadeAndTeleport()
    {
        baseui.enabled = true;
        yield return null;

        for (float i = 0; i < 1.2f; i += Time.deltaTime)
        {
            alpha = Mathf.Lerp(0f, 1f, i / 1.2f);
            doorTransition.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        

        player.transform.position = location.transform.position;
        yield return null;

        for (float i = 0; i < 1.2f; i += Time.deltaTime)
        {
            alpha = Mathf.Lerp(1f, 0f, i / 1.2f);
            doorTransition.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        baseui.enabled = false;
        yield return null;

        base.EndInteract();
        yield return null;
    }
}
