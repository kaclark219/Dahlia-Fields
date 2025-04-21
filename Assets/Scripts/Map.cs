using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] PlayerInteractor plint;
    [SerializeField] RectTransform playerHead;

    Dictionary<string, bool> talked;

    public void open(){
        plint.canInteract = false;
        plint.pm.canmove = false;
        playerHead.localPosition = new Vector2(18*(plint.transform.position.x + 12), 14*(plint.transform.position.y - 24));
    }

    public void close(){
        plint.canInteract = true;
        plint.pm.canmove = true;
        this.transform.gameObject.SetActive(false);
    }
}
