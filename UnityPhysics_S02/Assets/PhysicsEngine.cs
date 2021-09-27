using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour {

	public Vector3 velocity; //average velocity per frame
	public Vector3 netForce; 
	public List<Vector3> forceList = new List<Vector3> ();
	public float mass;
	void Start () {
		
	}
	
	void FixedUpdate () {
		AddForces ();
		UpdateVelocity ();
	
		//update position
		transform.position += velocity * Time.deltaTime;
	}

	void AddForces(){
		netForce = Vector3.zero;
		foreach(Vector3 force in forceList)
			{
			netForce += force;	
			}
	}

	void UpdateVelocity(){
	
		Vector3 accelaration = netForce / mass;   // a = F/m
		velocity += accelaration * Time.deltaTime;		// v = a * t
		
	}

}
