using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	[SerializeField] private int _number;
	[SerializeField] private bool _selected;
	[SerializeField] private TargetNumberManager _targetNumberManager;
	
	public int Number
	{
		get { return _number; }
		set { _number = value; }
	}
	
	public bool Selected
	{
		get { return _selected; }
		set { _selected = value; }
	}

	// Use this for initialization
	void Start ()
	{
		GetComponent<SpriteRenderer>().enabled = false;
		_selected = false;
	}
	
	// Update is called once per frame
	void Update () {	
	}

	public bool CheckSelectable()
	{
		var currentSum = SelectedBallListManager.instance.CalcListSum();
		print(currentSum);
		print(_number);
		print(currentSum+_number);
		print(TargetNumberManager.instance.TargetNumber);
		if (currentSum + _number > TargetNumberManager.instance.TargetNumber) return false;
		
		return true;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("UpperBoundary")) return;
		GetComponent<SpriteRenderer>().enabled = true;
	}
}
