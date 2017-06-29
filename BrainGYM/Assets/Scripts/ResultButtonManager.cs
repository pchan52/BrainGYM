using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButtonManager : MonoBehaviour {
	
	[SerializeField] private AudioClip _replayClip;
	[SerializeField] private AudioClip _titleClip;
	private AudioSource _audioSource;
	
	// Use this for initialization
	void Start ()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	public void ReplayButton()
	{
		_audioSource.PlayOneShot(_replayClip);
		Observable.Timer(TimeSpan.FromSeconds(1.5))
			.Subscribe(_ => SceneManager.LoadScene("Main"));
	}

	public void TitleButton()
	{
		_audioSource.PlayOneShot(_titleClip);
		Observable.Timer(TimeSpan.FromSeconds(1.5))
			.Subscribe(_ => SceneManager.LoadScene("Title"));
	}
}
