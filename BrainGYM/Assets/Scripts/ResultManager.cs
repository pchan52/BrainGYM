using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
	[SerializeField] private AudioClip _scoreSound;
	[SerializeField] private Text[] _scoreTexts;
	[SerializeField] private float _timeInterval;
	private int[] _scores;
	private AudioSource _audioSource;
	
	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource>();
		GetScores();
		StartCoroutine(ShowScoreCoroutine());
	}

	private void GetScores()
	{
		_scores = PlayerPrefsX.GetIntArray("Scores");

		for (var i = 0; i < _scoreTexts.Length; i++)
		{
			_scoreTexts[i].text = _scores[i].ToString();
		}
		var index = _scores[_scoreTexts.Length];
		if (index != -1)
		{
			_scoreTexts[index].color = Color.red;
		}
	}

	private IEnumerator ShowScoreCoroutine()
	{
		yield return new WaitForSeconds(_timeInterval);
		_scoreTexts[2].enabled = true;
		_audioSource.PlayOneShot(_scoreSound);
		yield return new WaitForSeconds(_timeInterval);
		_scoreTexts[1].enabled = true;
		_audioSource.PlayOneShot(_scoreSound);
		yield return new WaitForSeconds(_timeInterval);
		_scoreTexts[0].enabled = true;
		_audioSource.PlayOneShot(_scoreSound);
		
	}
}
