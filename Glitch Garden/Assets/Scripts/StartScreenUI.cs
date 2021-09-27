using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour
{
	public Button startBtn;
	public Button quitBtn;
	public Button optionsBtn;

	private LevelManager _levelManager = null;

	private void Start()
	{
		_levelManager = ((GameObject)Resources.Load("Level Manager")).GetComponent<LevelManager>();

		if (!_levelManager)
		{
			Debug.Log("Level Manger not found.");
			return;
		}

		startBtn.onClick.AddListener(OnClickStartBtn);
		quitBtn.onClick.AddListener(OnClickQuitBtn);
		optionsBtn.onClick.AddListener(OnClickOptionsBtn);
	}

	private void OnClickStartBtn()
	{
		_levelManager.LoadNextLevel();
	}

	private void OnClickQuitBtn()
	{
		_levelManager.QuitRequest();
	}

	private void OnClickOptionsBtn()
	{
		_levelManager.LoadLevel(Constant.OPTIONS_SCENE_NAME);
	}
}