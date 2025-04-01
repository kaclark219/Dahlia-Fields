using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartNoteBehavior : MonoBehaviour
{
    [SerializeField] ShowImageInteractable ShowImageInteractable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerInteractor>().canInteract)
        {
            ShowImageInteractable.OnInteract();
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerInteractor>().canInteract)
        {
            ShowImageInteractable.OnInteract();
            this.gameObject.SetActive(false);
        }
    }
}

