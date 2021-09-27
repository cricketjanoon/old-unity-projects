using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!autoPlay)
            MoveWithMouse();
        else
            AutoPlay();
	}

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlock = Input.mousePosition.x / Screen.width * 16;
        print(mousePosInBlock);
        paddlePos.x = Mathf.Clamp(mousePosInBlock, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {

        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPosition = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPosition.x, 0.5f, 15.5f);
        this.transform.position = paddlePos;

    }
}
