using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

	void Update () {
		rigidbody2D.isKinematic = Movement.Instance.hasSister;	
	}
}
