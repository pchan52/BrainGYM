using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	[SerializeField] private ScoreRate _scoreRate;
	[SerializeField] private Text _scoreText;
	[SerializeField] private float _score;

	// Use this for initialization
	void Start()
	{
		_score = 0;
	}

	// Update is called once per frame
	void Update()
	{
		_scoreText.text = _score.ToString();
	}

	public void CalcScore(List<GameObject> list)
	{
		var _rate = _scoreRate.Rate(list);
		var _sum = list.Sum(obj => obj.GetComponent<Ball>().Number);
		_score = _rate * _sum * 100;
	}
}