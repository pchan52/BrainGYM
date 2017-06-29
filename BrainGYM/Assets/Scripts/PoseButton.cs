using UnityEngine;
using UnityEngine.UI;

public class PoseButton : MonoBehaviour
{
	[SerializeField] private Image _poseImage;
	[SerializeField] private Image _playImage;

	// Use this for initialization
	void Start ()
	{
		_poseImage.enabled = true;
		_playImage.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GamePoseButton()
	{
		if (GameManager.instance.Isplaying)
		{
			print("aaa");
			_playImage.enabled = true;
			_poseImage.enabled = false;
			GameManager.instance.Isplaying = false;
		}
		else
		{
			_playImage.enabled = false;
			_poseImage.enabled = true;
			GameManager.instance.Isplaying = true;
		}
	}
}
