using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public float autoLoadNextLevelAfter;

	private void Start()
	{
		if (autoLoadNextLevelAfter == 0)
		{
			Debug.Log("Level auto load disabled");
		}
		else
		{
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name)
	{
		Debug.Log("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest()
	{
		Debug.Log("Quit requested");
		Application.Quit();
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadMainMenuScene()
	{
		LoadLevel(Constant.MAIN_MENU_SCENE_NAME);
	}

	public void LoadWinScreen()
	{
		LoadLevel(Constant.WIN_SCENE_NAME);
	}

	public void LoadLoseScreen()
	{
		LoadLevel(Constant.LOSE_SCENE_NAME);
	}
}