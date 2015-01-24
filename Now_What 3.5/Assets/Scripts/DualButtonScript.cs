using UnityEngine;
using System.Collections;

public class DualButtonScript : MonoBehaviour {

	private SpriteRenderer renderer;
	public bool pressed = false;

	void Awake()
	{
		renderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player" && Input.GetKeyDown(KeyCode.E))
		{
			DualButtonsManagerScript.Instance.counter++;
			transform.collider2D.enabled = false;
			pressed = true;
			StartCoroutine(wait());
		}

		else if (col.tag == "Alice" && Input.GetKeyDown(KeyCode.Q))
		{
			DualButtonsManagerScript.Instance.counter++;
			transform.collider2D.enabled = false;
			pressed = true;
			StartCoroutine(wait());
		}
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
