using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string level)
    {
        Brick.BreakableBricks = 0;
       // Debug.Log("Level loaded: " + level);
        //Application.LoadLevel(level);
        SceneManager.LoadScene(level);

    }


    public void BrickDestroyed()
    {
        if (Brick.BreakableBricks <= 0)
            LoadNextLevel();


    }

    public void QuitLevel()
    { 
        Debug.Log("Quit Pressed.");
    }

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
        Brick.BreakableBricks = 0;
    }
}
