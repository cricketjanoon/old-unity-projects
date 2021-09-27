using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string level)
    {

        Debug.Log("Level loaded: " + level);
        //Application.LoadLevel(level);
        SceneManager.LoadScene(level);

    }
    
    public void QuitLevel()
    {


        Debug.Log("Quit Pressed.");
    }

        
}
