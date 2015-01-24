using UnityEngine;
using System.Collections;

public class RampScript : MonoBehaviour {

	public bool hasRamp = false;
	private Transform player;
	private Transform triggerPlace;
	public Transform target;
	public static RampScript Instance;

	void Awake()
	{
		triggerPlace = transform.FindChild("TriggerPlace");
		Instance = this;
	}

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.tag == "Player")
		{
			player = col.transform;
			//Message
			print("E to pick up ramp");
			if (Input.GetKeyDown(KeyCode.E))
			{
				hasRamp = true;
				Movement.Instance.animator.SetBool("hasPlank", true);
			}
		}
	}

	void Update()
	{
		if (hasRamp) transform.position = player.position;
		if (hasRamp && TriggerPlaceScript.Instance.canPlace)
		{
			//prompt
			print("Press X.");
			if (Input.GetKeyDown(KeyCode.X))
			{
				hasRamp = false;
				Movement.Instance.animator.SetBool("hasPlank", false);
				transform.position = target.position;
				transform.rotation = target.rotation;
				transform.collider2D.isTrigger = false;
			}
		}
	}
}
