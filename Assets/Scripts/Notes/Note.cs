using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

public class Note : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bpm;

    public Score scoreKeeper;

    public Sprite[] emotes;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = emotes[Random.Range(0, 3)];
    }

    private void FixedUpdate()
    {
        // Can adjust speed using bpm value
        rb.velocity = bpm * Vector2.left;
    }
}
