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
    private FadeInFadeOut transition;
    float alpha = 0f; 

    public override void Awake()
    {
        base.Awake();
        transition = FindObjectOfType<FadeInFadeOut>();
        player = GameObject.Find("Player");
    }

    public override void Start()
    {
        base.Start();
    }

    public override void OnInteract()
    {
        base.OnInteract();
        transition.StartTransition(TeleportPlayer, base.EndInteract);
    }

    private void TeleportPlayer()
    {
        player.transform.position = location.transform.position;
    }
}
