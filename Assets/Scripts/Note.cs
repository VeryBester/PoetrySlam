using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool canHit, isTopRow;

    public float bpm;

    public int scoreRange;

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
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
        {
            // Need to check how close to correct it is for scoring
            if (canHit)
            {
                scoreKeeper.UpdateScore(100);
            }
            else
            {
                scoreKeeper.UpdateScore(0);
            }
            Destroy(gameObject);
        }
    }

    private void DoLowerInput()
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            // Need to check how close to correct it is for scoring
            if (canHit)
            {
                scoreKeeper.UpdateScore(100);
            }
            else
            {
                scoreKeeper.UpdateScore(0);
            }
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        // Can adjust speed using bpm value
        rb.velocity = bpm * Vector2.left;
    }

    private void OnBecameInvisible()
    {
        scoreKeeper.UpdateScore(0);
        Destroy(gameObject);
    }
}
