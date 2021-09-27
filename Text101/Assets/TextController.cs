using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {


    public Text text;

	// Use this for initialization
	void Start () {
        text.text = "What the hell is going on?";		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            text.text = "Yeah, return button is pressed.";
        }
            	
	}
}
