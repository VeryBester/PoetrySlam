using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndComboCounter : MonoBehaviour
{
    public Score scoreKeeper;

    public Text score, combo, health;

    public Text finalScore, finalCombo;

    // Update is called once per frame
    void Update()
    {
        // It's baby simple we can change later
        score.text = "Score: " + scoreKeeper.GetScore();
        finalScore.text = "Score: " + scoreKeeper.GetScore();
        combo.text = "Combo: " + scoreKeeper.GetCombo();
        finalCombo.text = "Combo: " + scoreKeeper.GetCombo();
        health.text = "HP: " + scoreKeeper.GetHealth();
    }
}
