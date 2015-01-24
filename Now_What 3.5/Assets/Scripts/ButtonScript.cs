using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {


	private Transform door;
	private SpriteRenderer renderer;

	void Awake()
	{
		door = transform.FindChild("Hatch");
		renderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player" && Input.GetKeyDown(KeyCode.E))
		{
			renderer.color = Color.green;
			door.rotation = Quaternion.identity;
		}

		else if (col.tag == "Alice" && Input.GetKeyDown(KeyCode.Q))
		{
			renderer.color = Color.green;
			door.rotation = Quaternion.identity;
		}
	}
}
