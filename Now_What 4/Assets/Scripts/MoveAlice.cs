using UnityEngine;
using System.Collections;

public class MoveAlice : MonoBehaviour {

	private Vector3 orpos;
	private Vector3 difference;
	private Vector3 aliceOrPos;
	private Transform alice;

	void Awake()
	{
		orpos = transform.position;
		alice = null;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Alice")
		{
			alice = col.transform;
			aliceOrPos = alice.localPosition;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Alice")
		{
			alice.localPosition = aliceOrPos;
			alice = null;
		}
	}

	void Update () {
		difference = transform.position - orpos;
		if (alice != null) alice.Translate(difference);
		orpos = transform.position;

	}
}
