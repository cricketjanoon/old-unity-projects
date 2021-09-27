using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int score;
    private Text score1;



    private void Start()
    {
        score1 = GetComponent<Text>();
    }

    public void Score(int points)
    {
        score += points;
        score1.text = score +"";
    }

    void Reset()
    {
        score = 0;
        score1.text = score + "";
    }



}
