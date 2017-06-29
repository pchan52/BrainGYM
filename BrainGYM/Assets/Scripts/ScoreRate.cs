using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRate : MonoBehaviour {

	public float Rate(List<GameObject> list)
	{
		var length = list.Count;
		switch (length)
		{
			case 3:
				return 1.0f;
			case 4:
				return 1.1f;
			case 5:
				return 1.2f;
			case 6:
				return 1.3f;
			default:
				return 1.5f;
		}
	}

}
