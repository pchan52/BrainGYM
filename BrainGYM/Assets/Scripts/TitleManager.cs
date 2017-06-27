using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void StartButton()
	{
		SceneManager.LoadScene("Main");
	}

	public void RuleButton()
	{
		SceneManager.LoadScene("Rule");
	}
}

