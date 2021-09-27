using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {


    int max;
    int min;
    int guess;

    public Text text;
    int maxGuessAllowed = 10;
	// Use this for initialization
	void Start () {

        StartGame();        

	}

    public void GuessHigher()
    {

        min = guess;
        guess = Random.Range(min, max);
        guess = (max + min) / 2;
        text.text = guess.ToString();
        maxGuessAllowed--;
        if (maxGuessAllowed <= 0)
        {
            Application.LoadLevel("Win");
        }
        print("Higher or lower than " + guess);

    }

    public void GuessLower()
    {

        max = guess;
        guess = Random.Range(min, max);
        guess = (max + min) / 2;
        guess = (max + min) / 2;
        text.text = guess.ToString();
        maxGuessAllowed--;
        if (maxGuessAllowed <= 0)
        {
            Application.LoadLevel("Win");
        }
        print("Higher or lower than " + guess);
    }


    void StartGame()
    {
        max = 1000;
        min = 1;
        guess = Random.Range(1, 1000) ;

        print("|==================================== |");
        print("Welcome to Number Wizard!");
        print("Pick up a number in  you head......");
        print("The highest you can pick is " + max);
        print("The lowest number you can pick is " + min);
        print("Is you number higher or lower than " + guess + "?");
        print("UP = higher, DOWN = lower, RETURN = equal");
        max = max + 1;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GuessHigher();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GuessLower();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            LevelManager m = new LevelManager();
            m.LoadLevel("Win");
        }

	}
}
