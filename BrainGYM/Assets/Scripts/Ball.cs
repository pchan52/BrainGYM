using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	[SerializeField] private int _number;
	[SerializeField] private bool _selected = false;
	

	public int Number
	{
		get { return _number; }
		set { _number = value; }
	}
	
	public bool Selected
	{
		get { return _selected; }
		set { _selected = value; }
	}


	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("UpperBoundary"))
		{
			GetComponent<SpriteRenderer>().enabled = true;
		}
	}

	// Use this for initialization
	void Start ()
	{
		GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {	
	}
}
