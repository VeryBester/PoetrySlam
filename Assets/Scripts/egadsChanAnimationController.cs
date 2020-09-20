using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egadsChanAnimationController : MonoBehaviour
{
    public GameController gameController;
    private Animator animator;

    private bool hit = false;
    private bool running = false;

    private void Start() {
        animator = GetComponent<Animator>();
        // if(gameController.startGame)
        // {
        //     running = true;
        //     animator.SetBool("Running", gameController.startGame);
        // }
    }

    private void Update() {
        animator.SetBool("Running", gameController.startGame);

        if(Input.GetKeyDown(GameConstants.botButton1) || Input.GetKeyDown(GameConstants.botButton2) 
                || Input.GetKeyDown(GameConstants.topButton1) || Input.GetKeyDown(GameConstants.topButton2))
        {
            hit = true;
            
        }
        else
        {
            hit = false;
        }
        animator.SetBool("Hit", hit);
    }



}
