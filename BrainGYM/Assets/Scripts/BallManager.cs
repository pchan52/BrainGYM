using System;
using UnityEngine;
using UniRx;
using Random = UnityEngine.Random;

public class BallManager : SingletonMonoBehaviour<BallManager>
{
    [SerializeField] private float _generateBallTimeSpan;
    [SerializeField] private float _width;
    [SerializeField] private float _hight;
    [SerializeField] private GameObject _ball;
    [SerializeField] private Sprite[] _ballsprites;
    private readonly Subject<int> _subject = new Subject<int>();
	
    //ストリームの作成
    public void Setup()
    {
        _subject
            .Delay(TimeSpan.FromSeconds(_generateBallTimeSpan))
            .Subscribe(_ => GenerateBall());
    }

    // オブジェクトの透明度を変化させる
    public void ChangeColor(GameObject obj, float alpha)
    {
        var ballSprite = obj.GetComponent<SpriteRenderer>();
        ballSprite.color = new Color(ballSprite.color.r,ballSprite.color.g,ballSprite.color.b,alpha);
    }
	
    // ボールを指定個作成
    public void BallMaker(int count)
    {
        for (var i = 0; i < count; i++)
        {
            _subject.OnNext(i);
        }
    }

    private void GenerateBall()
    {
        //ballをInstantiate 
        var ball = Instantiate(_ball);
        var x =  Random.Range( -_width, _width);
        ball.transform.position = new Vector2(x,_hight); //instantiate positionの指定
        var length = _ballsprites.Length;
        var i = Random.Range(0, length); //配列長分のボールの種類
        ball.GetComponent<Ball>().Number = i; //ボールそれぞれにNumberを格納
        var ballSprite = ball.GetComponent<SpriteRenderer>(); 
        if (_ballsprites != null)  ballSprite.sprite = _ballsprites[i]; //spriteの指定
    }
}

