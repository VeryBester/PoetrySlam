﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool canHit, isTopRow, isPastBar;

    public float bpm;

    public float scoreAccMult;

    public AudioSource audioSource;

    public Score scoreKeeper;

    public GameObject nextNote;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextNote == null)
        {
            if (isTopRow)
            {
                DoTopInput();
            }
            else
            {
                DoLowerInput();
            }
        }
    }

    private void DoTopInput()
    {
        if (Input.GetKeyDown(GameConstants.topButton1) || Input.GetKeyDown(GameConstants.topButton2))
        {
            // Need to check how close to correct it is for scoring
            if (canHit)
            {
                audioSource.Play();
                scoreKeeper.UpdateScore((int) (scoreAccMult * 100));
                Destroy(gameObject);
            }
            else
            {
                scoreKeeper.UpdateScore(0);
            }
        }
    }

    private void DoLowerInput()
    {
        if (Input.GetKeyDown(GameConstants.botButton1) || Input.GetKeyDown(GameConstants.botButton2))
        {
            // Need to check how close to correct it is for scoring
            if (canHit)
            {
                audioSource.Play();
                scoreKeeper.UpdateScore((int) (scoreAccMult * 100));
                Destroy(gameObject);
            }
            else
            {
                scoreKeeper.UpdateScore(0);
            }
        }
    }

    private void FixedUpdate()
    {
        // Can adjust speed using bpm value
        rb.velocity = bpm * Vector2.left;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}