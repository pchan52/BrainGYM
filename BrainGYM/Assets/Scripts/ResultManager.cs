using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
	[SerializeField] private Text[] _scoreTexts;
	private int[] _scores;
	private Animator _animator;
	
	// Use this for initialization
	void Start () {
//		_scores = new[] {1, 2, 3, 0};
//		PlayerPrefsX.SetIntArray("Scores", _scores);
		_animator = GetComponent<Animator>();
		GetScores();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void GetScores()
	{
		_scores = PlayerPrefsX.GetIntArray("Scores");
		for (var i = 0; i < _scoreTexts.Length; i++)
		{
			print("a");
			_scoreTexts[i].text = _scores[i].ToString();
		}
		var index = _scores[_scoreTexts.Length];
		if (index != -1)
		{
			_scoreTexts[index].color = Color.red;
		}
		_animator.SetTrigger("show");	
	}
}
