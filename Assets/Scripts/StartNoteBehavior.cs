using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartNoteBehavior : MonoBehaviour
{
    [SerializeField] ShowImageInteractable ShowImageInteractable;

    private void OnEnable()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerInteractor>().canInteract)
        {
            ShowImageInteractable.OnInteract();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerInteractor>().canInteract)
        {
            ShowImageInteractable.OnInteract();
            GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}

