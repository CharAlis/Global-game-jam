using UnityEngine;
using System.Collections;

public class DualButtonScript : MonoBehaviour {

	private SpriteRenderer renderer;
	public bool pressed = false;
	private bool showText = true;

	void Awake()
	{
		renderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player" && showText) Texts.Instance.ChangeText("[E]");
		if (col.tag == "Player" && Input.GetKeyDown(KeyCode.E))
		{
			Texts.Instance.ResetText();
			showText = false;
			DualButtonsManagerScript.Instance.counter++;
			transform.collider2D.enabled = false;
			pressed = true;
			StartCoroutine(wait());
		}

		if (col.tag == "Alice" && showText) Texts.Instance.ChangeText("[Q]");
		if (col.tag == "Alice" && Input.GetKeyDown(KeyCode.Q))
		{
			Texts.Instance.ResetText();
			showText = false;
			DualButtonsManagerScript.Instance.counter++;
			transform.collider2D.enabled = false;
			pressed = true;
			StartCoroutine(wait());
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Alice" || col.tag == "Player") Texts.Instance.ResetText();
	}

	void Update()
	{
		if (pressed)
		{
			renderer.color = Color.green;
		}
		else
		{
			renderer.color = Color.red;
		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(1f);
		pressed = false;
		DualButtonsManagerScript.Instance.counter--;
		transform.collider2D.enabled = true;
	}

}
