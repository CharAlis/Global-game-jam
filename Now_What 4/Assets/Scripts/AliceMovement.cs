using UnityEngine;
using System.Collections;

public class AliceMovement : MonoBehaviour {

	public static AliceMovement Instance;
	public Animator aliceAnimator;


	void Awake()
	{
		Instance = this;
		aliceAnimator = GetComponent<Animator>();
	}
	/*
	void Update()
	{
		if ( ((transform.localScale.x == -1) && Movement.Instance.facingRight) || ((transform.localScale.x == 1) && !Movement.Instance.facingRight))
		{
			print(transform.forward.x);
			Vector3 myScale = transform.localScale;
			myScale.x *= -1;
			transform.localScale = myScale;
			print(transform.right.y);
		}
	}*/

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.F) && !Movement.Instance.hasSister)
			{
				StartCoroutine(ReturnSister(col));
			}
		}
	}

	IEnumerator ReturnSister(Collider2D bigBro) {
		while (Input.GetKey(KeyCode.F)) yield return null;
		// Facing direction correction
		if (transform.lossyScale.x != bigBro.transform.lossyScale.x) {
			Vector3 myScale = transform.localScale;
			myScale.x *= -1;
			transform.localScale = myScale;
		}

		transform.SetParent(bigBro.transform);
		Movement.Instance.hasSister = true;
		Movement.Instance.maxSpeed = 6f;

		transform.localPosition = Movement.Instance.alicePos;
		aliceAnimator.SetBool("isAlone", false);



		yield return null;
	}
}
