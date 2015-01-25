using UnityEngine;
using System.Collections;

public class Squasher : MonoBehaviour {

	public float smashSpeed = 30f;
	public float riseSpeed = 10f;
	public float delay = 2f;

	void Start () {
		
	}

	IEnumerator Smash () {
		float temp = transform.position.y;
		//while ( transform.position.y + temp > 3 ) transform.position -= smashSpeed();
		yield return null;
	}
	
	IEnumerator Cycle () {
		float temp = transform.position.y;
		//while ( transform.position.y - temp < 3  )transform.position.y += riseSpeed ; 
		yield return null;
	}
}
