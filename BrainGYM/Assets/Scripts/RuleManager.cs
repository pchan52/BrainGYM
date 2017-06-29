using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RuleManager : MonoBehaviour
{

	[SerializeField] private Text[] _rule;
	[SerializeField] private GameObject _startButton;
	[SerializeField] private GameObject _backButton;
	[SerializeField] private float _time;
	[SerializeField] private AudioClip _startClip;
	[SerializeField] private AudioClip _titleClip;
	private AudioSource _audioSource;
	
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(ShowRuleCoroutine(_rule));
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator ShowRuleCoroutine(Text[] texts)
	{
		foreach (Text t in texts)
		{
			yield return new WaitForSeconds(_time);
			t.enabled = true;
		}
		
		yield return new WaitForSeconds(_time);
		_startButton.SetActive(true);
		_backButton.SetActive(true);
	}

	public void StartButton()
	{
		_audioSource.PlayOneShot(_startClip);
		Observable.Timer(TimeSpan.FromSeconds(1.5))
			.Subscribe(_ => SceneManager.LoadScene("Main"));
	}

	public void BackButton()
	{
		_audioSource.PlayOneShot(_titleClip);
		Observable.Timer(TimeSpan.FromSeconds(1.5))
			.Subscribe(_ => SceneManager.LoadScene("Title"));
	}
}
