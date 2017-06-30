using UnityEngine;
using UnityEngine.UI;

public class TargetNumberManager : SingletonMonoBehaviour<TargetNumberManager> {
	
	[SerializeField] private Text _targetnumberText;
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
	
	public void ReturnNumber()
	{
		_targetNumber = (int) Random.Range(3f, _maxNumber);
		_targetnumberText.text = _targetNumber.ToString();
	}
}
