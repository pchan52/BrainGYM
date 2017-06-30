using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class RxCountDownText : MonoBehaviour {
	
	[SerializeField] private RxCountDownTimer rxCountDownTimer;

	private Text text;

	void Start()
	{
		text = GetComponent<Text>();

		//タイマの残り時間を描画する
		rxCountDownTimer
			.CountDownObservable
			.Subscribe(time =>
			{
				//OnNextで時刻の描画
				text.text = time.ToString();
			}, () =>
			{
				//OnCompleteで文字を消す
				text.text = string.Empty;
			});

		//タイマが10秒以下になったタイミングで色を赤くする
		rxCountDownTimer
			.CountDownObservable
			.First(timer => timer <= 3)
			.Subscribe(_ => text.color = Color.red);
	}
}
