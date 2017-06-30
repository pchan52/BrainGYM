using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RxCountDownSound : MonoBehaviour
{
	[SerializeField] private float _loadscenetime;
	[SerializeField] private AudioClip _setCountDownTick;
	[SerializeField] private RxCountDownTimer _rxCountDownTimer;
	private AudioSource _audioSource;

	
	void Start()
	{
		_audioSource = GetComponent<AudioSource>();

		//カウントが10秒以下になったらSEを1秒毎に鳴らす
		_rxCountDownTimer
			.CountDownObservable
			.Where(time => time <= 3)
			.Subscribe(_ => _audioSource.PlayOneShot(_setCountDownTick));

		//カウントが完了したら指定秒まってシーン遷移
		_rxCountDownTimer
			.CountDownObservable
			.Delay(TimeSpan.FromSeconds(_loadscenetime))
			.Subscribe(_ => { ;}, () => SceneManager.LoadScene("Result"));
	}
}
