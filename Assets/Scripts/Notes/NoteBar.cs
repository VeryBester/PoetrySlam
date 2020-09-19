using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponentInParent<Note>().canHit = true;
        switch (other.tag)
        {
            case "Early":
                other.GetComponentInParent<Note>().scoreAccMult = 0.5f;
                break;
            case "Perfect":
                other.GetComponentInParent<Note>().scoreAccMult = 1f;
                break;
            case "Late":
                other.GetComponentInParent<Note>().scoreAccMult = 0.5f;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Late"))
        {
            other.GetComponentInParent<Note>().canHit = false;
            // other.gameObject.GetComponent<Note>().scoreKeeper.UpdateScore(0);
            Destroy(other.GetComponentInParent<Note>().gameObject);
        }
    }
}
