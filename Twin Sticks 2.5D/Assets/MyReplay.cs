using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyReplay : MonoBehaviour
{

	private const int bufferFrames = 100;
	private MyKeyFrame[] keyFrames = new MyKeyFrame [bufferFrames];
	private Rigidbody rb;
	private GameManager manager;

	void Start ()
	{
		manager = FindObjectOfType<GameManager> ();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (manager.recording)
			Record ();
		else
			PlayBack ();
	}

	void PlayBack ()
	{
		rb.isKinematic = true;	
		int frame = Time.frameCount % bufferFrames;

		transform.position = keyFrames [frame].position;
		transform.rotation = keyFrames [frame].rotation;
		
	}

	void Record ()
	{
		rb.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		Debug.Log (frame);
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
	}
}


public struct MyKeyFrame
{
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame (float frameTime, Vector3 position, Quaternion rotation)
	{
		this.frameTime = frameTime;
		this.position = position;
		this.rotation = rotation;
	}


}