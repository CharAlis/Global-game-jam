using UnityEngine;
using System.Collections;

public class ChainPlatformScript : MonoBehaviour {

	private SpriteRenderer renderer;
	private Transform lift;
	private Vector3 orpos;
	private bool goingDown = false;

	void Awake()
	{
		lift = transform.FindChild("Lift");
		renderer = GetComponent<SpriteRenderer>();
		orpos = lift.position;
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			if (Input.GetKey(KeyCode.E))
			{
				renderer.color = Color.green;
				lift.Translate(Vector3.up * 0.5f * Time.deltaTime);
			}
			if (Input.GetKeyUp(KeyCode.E))
			{
				goingDown = true;
				renderer.color = Color.red;
			}
		}

		else if (col.tag == "Alice")
		{
			if (Input.GetKey(KeyCode.Q))
			{
				renderer.color = Color.green;
				lift.Translate(Vector3.up * 0.5f * Time.deltaTime);
			}
			if (Input.GetKeyUp(KeyCode.Q))
			{
				renderer.color = Color.red;
				goingDown = true;
			}
		}
	}

	void Update()
	{
		if (goingDown && lift.position.y >= orpos.y) lift.Translate(Vector3.down * 0.25f * Time.deltaTime);
	}
}
