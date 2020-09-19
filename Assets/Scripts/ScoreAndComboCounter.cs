using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndComboCounter : MonoBehaviour
{
    public Score scoreKeeper;

    public Text score, combo;

    // Update is called once per frame
    void Update()
    {
        // It's baby simple we can change later
        score.text = "Score: " + scoreKeeper.GetScore();
        combo.text = "Combo: " + scoreKeeper.GetCombo();
    }
}
