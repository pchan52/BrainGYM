using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownTimer : SingletonMonoBehaviour<CountDownTimer>
{
	[SerializeField] private float _time;
	[SerializeField] private Image _timerImage;
	[SerializeField] private Text _timerText;
//	[SerializeField] private Text _countdownText;
	[SerializeField] private RxCountDownTimer _rxCountDownTimer;
	private AudioSource _audioSource;
	private readonly Subject<Unit> _subject = new Subject<Unit>();
	private bool _startBgm;

	// Use this for initialization
	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_startBgm = false;
		_subject
			.Delay(TimeSpan.FromSeconds(1.5))
			.Subscribe(_ => SceneManager.LoadScene("Result"));
	}

	// Update is called once per frame
	void Update()
	{
		_timerImage.fillAmount = _time / 60;
		if (!GameManager.instance.Isplaying) return;
		if (_time > 0)
		{
			if (!_startBgm)
			{
				_audioSource.Play();
				_startBgm = true;
			}
			_time -= Time.deltaTime;
			var currentTime = (int) _time;
			_timerText.text = currentTime.ToString();
			if (_time < 4)
			{
				_rxCountDownTimer.StartCountDown();
			}
		}

		if (!(_time < 1)) return;
		_time = 0;

		GameManager.instance.Isplaying = false;
		_audioSource.Stop();
		_subject.OnNext(Unit.Default);
	}
}
