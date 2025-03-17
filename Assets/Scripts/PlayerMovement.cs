using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4.0f;
    public Rigidbody2D rb;
    [SerializeField] private Vector2 dir;
    [SerializeField] Transform SpawnLocation;
    Animator anim;
    public bool canmove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SpawnLocation = GameObject.Find("Spawn").transform;
    }

    void Start()
    {
        ResetLocation();
        canmove = true;
    }

    void Update()
    {
        //Movement Logic
        if(canmove){
            dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            dir = Vector3.Normalize(dir);
            rb.velocity = dir * speed;
            if(dir.x != 0 || dir.y != 0){
                anim.SetFloat("X", dir.x);
                anim.SetFloat("Y", dir.y);
            }
            anim.SetBool("IsMoving", dir != Vector2.zero);
        }
        else
        {
            anim.SetBool("IsMoving", false);
            rb.velocity = Vector2.zero;
        }
    }

    public void ResetLocation()
    {
        transform.position = SpawnLocation.position;
        transform.rotation = SpawnLocation.rotation;
        anim.SetFloat("X", 0);
        anim.SetFloat("Y", 0);

        rb.velocity = Vector2.zero;
    }
}
