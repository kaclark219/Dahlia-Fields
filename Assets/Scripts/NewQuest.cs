using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewQuest : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector2(transform.position.x, Mathf.Sin(Time.time * 2f) * 0.2f - 1);
    }
}