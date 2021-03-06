﻿using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class SelectedBallListManager : SingletonMonoBehaviour<SelectedBallListManager>
{

	private List<GameObject> _removableBallList;
	private Subject<GameObject> _subject = new Subject<GameObject>();

	public List<GameObject> RemovableBallList
	{
		get { return _removableBallList; }
	}
	// Use this for initialization
	void Start()
	{
		_removableBallList = new List<GameObject>();
		
		_subject
			.Delay(TimeSpan.FromSeconds(0.1))
			.Subscribe(obj => Destroy(obj));
	}

	public void ClearList()
	{
		_removableBallList.Clear();
	}

	public void PushToList(GameObject obj)
	{	
		obj.GetComponent<Ball>().Selected = true;
		BallManager.instance.ChangeColor(obj,0.5f);
		_removableBallList.Add(obj);
	}
	
	public void RemoveFromList(GameObject obj, GameObject lastball)
	{
		lastball.GetComponent<Ball>().Selected = false;
		BallManager.instance.ChangeColor(lastball,1.0f); //リストの中のボールの透明度を戻す
		var length = _removableBallList.Count;
		_removableBallList.RemoveAt(length-1);
	}

	public void SelectedBallToUnselected(GameObject obj)
	{
		obj.GetComponent<Ball>().Selected = false;
		BallManager.instance.ChangeColor(obj,1.0f); //リストの中のボールの透明度を戻す
	}

	public int CalcListSum()
	{
		if (_removableBallList.Count == 0)
		{
			return 0;
		}
		return _removableBallList.Sum(obj => obj.GetComponent<Ball>().Number);
	}

	public void DestroySelectedBall(List<GameObject> list)
	{
		for (var i = 0; i < list.Count; i++)
		{
			var obj = list[i];
			_subject.OnNext(obj);
		}
	}
	
}
