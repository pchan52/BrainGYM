using UnityEngine;

public class PassButton : MonoBehaviour {
	
	[SerializeField] private AudioClip _passClip;
	private AudioSource _audioSource;

	// Use this for initialization
	void Start ()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	public void PassNumberButton()
	{
		_audioSource.PlayOneShot(_passClip);
		TargetNumberManager.instance.ReturnNumber();
	}
}
