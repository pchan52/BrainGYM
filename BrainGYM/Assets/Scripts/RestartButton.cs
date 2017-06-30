using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
	[SerializeField] private float _loadSceneTimeSpan;
	[SerializeField] private AudioClip _restartClip;
	private AudioSource _audioSource;

	// Use this for initialization
	void Start ()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	public void BackTitleButton()
	{
		_audioSource.PlayOneShot(_restartClip);
		Observable.Timer(TimeSpan.FromSeconds(_loadSceneTimeSpan))
			.Subscribe(_ => SceneManager.LoadScene("Title"));
	}
}
