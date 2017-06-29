using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetNumberManager : SingletonMonoBehaviour<TargetNumberManager> {
	
	[SerializeField] private Text _targetnumberText;
//	[SerializeField] private Text _insufficientNumber; //不足分の数
//	[SerializeField] private SelectedBallListManager _selectedBallListManager;
	[SerializeField] private float _maxNumber;
	private int _targetNumber;

	public int TargetNumber
	{
		get { return _targetNumber; }
	}

	// Use this for initialization
	void Start () {
		ReturnNumber();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ReturnNumber()
	{
		_targetNumber = (int) Random.Range(3f, _maxNumber);
		_targetnumberText.text = _targetNumber.ToString();
	}

//	public void Insufficient(SelectedBallListManager sblm)
//	public void Insufficient()
//	{
//		var insufficient =  TargetNumber-sblm.CalcListSum();
//		var insufficient = _targetNumber - _selectedBallListManager.CalcListSum();
//		_insufficientNumber.text = insufficient.ToString();
//	}
}
