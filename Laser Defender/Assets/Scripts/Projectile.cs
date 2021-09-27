using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float demage = 100f;


    public float GetDemage()
    {
        return demage;
    }


    public void Hit()
    {
        Destroy(gameObject);
    }
}
