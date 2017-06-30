using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : SingletonMonoBehaviour<CountDownTimer>
{
	[SerializeField] private float _maxtime;
	[SerializeField] private Image _timerImage;
	[SerializeField] private Text _timerText;
	[SerializeField] private RxCountDownTimer _rxCountDownTimer;
	[SerializeField] private ScoreManager _scoreManager;
	private AudioSource _audioSource;
	private bool _startBgm;
	private float _time;

	// Use this for initialization
	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_startBgm = false;
		_time = _maxtime;
	}

	// Update is called once per frame
	void Update()
	{
		_timerImage.fillAmount = _time / _maxtime;
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
		_scoreManager.SaveScores();
		GameManager.instance.Isplaying = false;
		_audioSource.Stop();
	}
}
