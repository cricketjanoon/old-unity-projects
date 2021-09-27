using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public static MusicPlayer mp = null;


    private void Awake()
    {
        Debug.Log("Music player awake" + GetInstanceID());
    }
    // Use this for initialization
    void Start () {
        Debug.Log("Music Player started" + GetInstanceID());
        if (mp != null)
            Destroy(gameObject);
        else
        {
            mp = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
