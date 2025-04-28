using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective2 : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.rb.position.y > transform.position.y){
            sr.sortingOrder = 6;
        }else{
            sr.sortingOrder = 3;
        }
    }
}
