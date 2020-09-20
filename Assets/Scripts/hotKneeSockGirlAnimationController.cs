using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotKneeSockGirlAnimationController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     animator.SetBool("Happy", happy);

    //     animator.SetBool("Angry", angry);
    // }

    public void triggerHappy()
    {
        
        StartCoroutine("setHappy");
        Debug.Log("Setting happyy");
    }

    public void triggerAngry()
    {
        StartCoroutine("setAngry");
        Debug.Log("Setting angry");
    }

    IEnumerator setHappy()
    {
        animator.SetBool("Happy", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Happy", false);
    }

    IEnumerator setAngry()
    {
        animator.SetBool("Angry", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Angry", false);
    }
}
