using UnityEngine;
using System.Collections;

public class TriggerPlaceScript : MonoBehaviour {

	public bool canPlace = false;
	public static TriggerPlaceScript Instance;

	void Awake()
	{
		Instance = this;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			canPlace = true;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			canPlace = false;
		}
	}
}
