using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OffScreenDetect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<Note>() != null)
        {
            other.GetComponentInParent<Note>().scoreKeeper.UpdateScore(0);
            Destroy(other.GetComponentInParent<Note>().gameObject);
        }
    }
}
