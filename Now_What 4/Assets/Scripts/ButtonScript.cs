using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {


	private Transform door;
	private SpriteRenderer renderer;
	private bool showText = true;

	void Awake()
	{
		door = transform.FindChild("Hatch");
		renderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player" && showText) Texts.Instance.ChangeText("[E]");
		if (col.tag == "Player" && Input.GetKeyDown(KeyCode.E))
		{
			Texts.Instance.ResetText();
			showText = false;
			renderer.color = Color.green;
			door.rotation = Quaternion.identity;
		}
		if (col.tag == "Alice" && showText) Texts.Instance.ChangeText("[Q]");
		if (col.tag == "Alice" && Input.GetKeyDown(KeyCode.Q))
		{
			Texts.Instance.ResetText();
			showText = false;
			renderer.color = Color.green;
			door.rotation = Quaternion.identity;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Alice" || col.tag == "Player") Texts.Instance.ResetText();
	}
}
