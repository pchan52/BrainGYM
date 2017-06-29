using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartSign : MonoBehaviour
{
	private Text _startSign;

	// Use this for initialization
	void Start ()
	{
		_startSign = GetComponent<Text>();
		_startSign.enabled = true;

		StartCoroutine(StartSignCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator StartSignCoroutine()
	{
		yield return new WaitForSeconds(1f);
		_startSign.text = "Ready";
		yield return new WaitForSeconds(1f);
		_startSign.text = "Go!";
		yield return  new WaitForSeconds(0.5f);
		_startSign.enabled = false;
		GameManager.instance.Isplaying = true;
		BallManager.instance.BallMaker(50);
	}
}
