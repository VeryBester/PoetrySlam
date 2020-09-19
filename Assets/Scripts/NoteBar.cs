using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Note>().canHit = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<Note>().canHit = false;
    }
}
