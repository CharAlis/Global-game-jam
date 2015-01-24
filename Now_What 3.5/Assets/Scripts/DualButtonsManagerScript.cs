using UnityEngine;
using System.Collections;

public class DualButtonsManagerScript : MonoBehaviour {

	public static DualButtonsManagerScript Instance;
	private Transform door;

	void Awake()
	{
		Instance = this;
		door = transform.FindChild("Hatch");
	}

	public int counter = 0;

	void Update()
	{
		if (counter == 2)
		{
			door.rotation = Quaternion.identity;
		}
	}

}
