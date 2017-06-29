using System;
using UniRx;
using UnityEngine;

public class RxCountDownTimer : MonoBehaviour {

	public UniRx.IObservable<int> CountDownObservable
	{
		get
		{
			return _countDownObservable.AsObservable();
		}
	}

	private IConnectableObservable<int> _countDownObservable;

	void Awake()
	{
		_countDownObservable = CreateCountDownObservable(3).Publish();
	}

	public void StartCountDown()
	{
		_countDownObservable.Connect();
	}
	
	private UniRx.IObservable<int> CreateCountDownObservable(int CountTime)
	{
		return Observable
			.Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1)) 
			.Select(x => (int)(CountTime - x))                      
			.TakeWhile(x => x > 0);                                
	}
}
