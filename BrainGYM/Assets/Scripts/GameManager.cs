public class GameManager : SingletonMonoBehaviour<GameManager>
{
	private bool _isplaying = false;

	public bool Isplaying
	{
		get { return _isplaying; }
		set { _isplaying = value; }
	}

	// Use this for initialization
	void Start () {
		BallManager.instance.Setup();
	}
}
