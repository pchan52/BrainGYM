using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	[SerializeField] private ScoreRate _scoreRate;
	[SerializeField] private Text _scoreText;
	[SerializeField] private float _score;
	private int[] _scores;
	private bool _scoreChange;

	// Use this for initialization
	void Start()
	{
		_score = 0;
		_scores = PlayerPrefsX.GetIntArray("Scores",0,4);
		_scoreChange = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (GameManager.instance.Isplaying)
		{
			_scoreText.text = _score.ToString();
		}
		else
		{
			_scoreText.text = "0";
		}
	}

	public void CalcScore(List<GameObject> list)
	{
		var rate = _scoreRate.Rate(list);
		var sum = list.Sum(obj => obj.GetComponent<Ball>().Number);
		_score += rate * sum * 100;
	}

	public void SaveScores()
	{
		var index = -1;
		for (var i = 0; i < _scores.Length-1; i++)
		{
			if (_scores[i] < _score)
			{
				if (!_scoreChange)
				{
					index = i;
					_scoreChange = true;
				}
				var tmp = _scores[i];
				_scores[i] = (int) _score;
				_score = tmp;
			}
		}
		_scores[3] = index;
		PlayerPrefsX.SetIntArray("Scores", _scores);
	}
}