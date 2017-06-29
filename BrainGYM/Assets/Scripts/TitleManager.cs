using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
	[SerializeField] private AudioClip _startClip;
	[SerializeField] private AudioClip _ruleClip;
	private AudioSource _audioSource;
	// Use this for initialization
	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void StartButton()
	{
		
		_audioSource.PlayOneShot(_startClip);
		Observable.Timer(TimeSpan.FromSeconds(1.5))
			.Subscribe(_ => SceneManager.LoadScene("Main"));
	}

	public void RuleButton()
	{
		_audioSource.PlayOneShot(_ruleClip);
		Observable.Timer(TimeSpan.FromSeconds(1.5))
			.Subscribe(_ => SceneManager.LoadScene("Rule"));
	}
}

