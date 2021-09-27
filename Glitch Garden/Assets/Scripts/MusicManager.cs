using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Debug.Log("Don't destory on load: " + name);
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoadedMine;
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnSceneLoadedMine(Scene scene, LoadSceneMode mode)
	{
		int level = scene.buildIndex;

		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log("Playing clip: " + thisLevelMusic);

		if (thisLevelMusic)
		{ // If there's some music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoadedMine;
	}
}