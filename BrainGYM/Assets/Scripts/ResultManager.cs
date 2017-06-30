using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
	[SerializeField] private AudioClip _scoreSound;
	[SerializeField] private Text[] _scoreTexts;
	private int[] _scores;
	private Animator _animator;
	private AudioSource _audioSource;
	
	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
		_audioSource = GetComponent<AudioSource>();
		GetScores();
	}

	private void GetScores()
	{
		_scores = PlayerPrefsX.GetIntArray("Scores");

		for (var i = 0; i < _scoreTexts.Length; i++)
		{
			_scoreTexts[i].text = _scores[i].ToString();
			_audioSource.PlayOneShot(_scoreSound);
		}
		var index = _scores[_scoreTexts.Length];
		if (index != -1)
		{
			_scoreTexts[index].color = Color.red;
		}
		_animator.SetTrigger("show");	
	}
}
