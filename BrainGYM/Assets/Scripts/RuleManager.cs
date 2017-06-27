using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RuleManager : MonoBehaviour
{

	[SerializeField] private Text[] _rule;
	[SerializeField] private GameObject _startButton;
	[SerializeField] private GameObject _backButton;
	[SerializeField] private float _time;
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(ShowRuleCoroutine(_rule));
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
		SceneManager.LoadScene("Main");
	}

	public void BackButton()
	{
		SceneManager.LoadScene("Title");
	}
}
