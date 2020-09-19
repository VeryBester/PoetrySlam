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
            case "Late":
                other.GetComponentInParent<Note>().scoreAccMult = GameConstants.earlyLateMult;
                break;
            case "Perfect":
                other.GetComponentInParent<Note>().scoreAccMult = GameConstants.perfectMult;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Late"))
        {
            other.GetComponentInParent<Note>().canHit = false;
        }
    }
}
