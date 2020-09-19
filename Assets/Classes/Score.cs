using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private int totalScore, combo;

    private int health;

    private int maxHp, damage;

    public Score(int maxHp, int damage)
    {
        this.maxHp = maxHp;
        health = this.maxHp;
        this.damage = damage;
    }
    
    public void UpdateScore(int scoreIncrease)
    {
        totalScore += scoreIncrease;
        combo++;
        if (scoreIncrease == 0)
        {
            combo = 0;
            health -= damage;
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetScore()
    {
        return totalScore;
    }

    public int GetCombo()
    {
        return combo;
    }
}
