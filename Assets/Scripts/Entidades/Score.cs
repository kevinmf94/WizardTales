using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private int score;

    public Score(int score)
    {
        this.score = score;
    }

    public void setScore(int score)
    {
        this.score = score;
    }

    public int getScore()
    {
        return score;
    }

    public void incScore(int score)
    {
        this.score += score;
    }

    public void decScore(int score)
    {
        this.score -= score;
    }
}
