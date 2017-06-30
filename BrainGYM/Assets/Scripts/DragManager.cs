using UnityEngine;

public class DragManager : MonoBehaviour
{
	[SerializeField] private float _distance;
	[SerializeField] private SelectedBallListManager _selectedBallListManager;
	[SerializeField] private TargetNumberManager _targetNumberManager;
	[SerializeField] private ScoreManager _scoreManager;
	[SerializeField] private AudioClip _selectClip;
	private AudioSource _audioSource;
	
	// ドラッグしているかしていないか
	private bool _isDragging;
	//直前にドラッグしたボール
	private GameObject _lastBall;
	//2個前にドラッグしたボール
	private GameObject _beforeBall;
	
	// Use this for initialization
	void Start () {
		_isDragging = false;
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.instance.Isplaying != true) return;
		if (Input.GetMouseButton(0) && !_isDragging )
		{
			OnDragStart();		
		}else if (Input.GetMouseButtonUp(0))
		{
			OnDragEnd();		
		}else if(_isDragging)
		{
			OnDragging();
		}
	}

	private void OnDragStart()
	{
		SelectedBallListManager.instance.ClearList();
		var col = GetCurrentHitCollider();
		if (col.GetComponent<Ball>() == null) return; //選択したものがBallじゃなかったらreturn
		var colObj = col.gameObject;
		_lastBall = colObj;
		_audioSource.PlayOneShot(_selectClip);
		SelectedBallListManager.instance.PushToList(colObj);
		_isDragging = true;
	}

	private void OnDragging()
	{
		var col = GetCurrentHitCollider();
		if (col.GetComponent<Ball>() == null) return; //選択したものがBallじゃなかったらreturn
		var colObj = col.gameObject;
		if (colObj == _lastBall) return; //直前と同じものだったらreturn
		var dist = Vector2.Distance(_lastBall.transform.position, colObj.transform.position);
		if (dist > _distance) return; // 一定距離以上だったらreturn

		
		if (colObj.GetComponent<Ball>().Selected) //ballがすでに選択状態
		{
			var length = _selectedBallListManager.RemovableBallList.Count;
			if (length > 2)
			{
				var removableBallList = _selectedBallListManager.RemovableBallList;
				_beforeBall = removableBallList[length - 2];
				if (_beforeBall != colObj) return;
				_selectedBallListManager.RemoveFromList(colObj,_lastBall);
				_lastBall = colObj;
			}
			else
			{
				_selectedBallListManager.RemoveFromList(colObj,_lastBall);
				_lastBall = colObj;
			}
		}
		else
		{
			if (!colObj.GetComponent<Ball>().CheckSelectable()) return; //和が越える
			_audioSource.PlayOneShot(_selectClip);
			_lastBall = colObj;
			_selectedBallListManager.PushToList(colObj);
		}
	}

	private void OnDragEnd()
	{
		if (!_isDragging) return; 
		var removableBallList = _selectedBallListManager.RemovableBallList;
		var length = removableBallList.Count; 
		if (_selectedBallListManager.CalcListSum() == _targetNumberManager.TargetNumber && length >= 3)
		{
			_scoreManager.CalcScore(removableBallList);
			_selectedBallListManager.DestroySelectedBall(removableBallList);
			BallManager.instance.BallMaker(length); //削除した個数分 ボール作成
			_targetNumberManager.ReturnNumber();
		}else
		{
			for (var j = 0; j < length; j++)
			{
				_selectedBallListManager.SelectedBallToUnselected(removableBallList[j]);
			}
		}
		_selectedBallListManager.ClearList(); 
		_isDragging = false; //ドラッグをリセット
	}

	private Collider2D GetCurrentHitCollider()
	{
		var hitcol = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		return hitcol.collider;
	}
}
