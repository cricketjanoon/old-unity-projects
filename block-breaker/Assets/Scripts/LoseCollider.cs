﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {


    private LevelManager lm;
	// Use this for initialization
	void Start () {
        lm = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!");
        lm.LoadLevel("Lose");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        lm.LoadLevel("Lose");
        Debug.Log("Collision!");
    }


}