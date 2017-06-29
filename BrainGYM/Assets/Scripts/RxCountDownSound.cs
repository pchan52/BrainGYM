using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RxCountDownSound : MonoBehaviour {

	//効果音
	[SerializeField] private AudioClip _setCountDownTick;
//	[SerializeField] private AudioClip _setGameSound;
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

		//カウントが完了したタイミングでSEを鳴らす
//		_rxCountDownTimer
//			.CountDownObservable
//			.Subscribe(_ => { ;}, () => _audioSource.PlayOneShot(_seCountDownEnd));
	}
}
