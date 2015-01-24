using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public static Movement Instance;

	private Transform groundcheck;
	private float groundradius = 0.46f;
	public bool  grounded = false;

	[SerializeField] private LayerMask GroundLayer;
	private float maxSpeed = 10f;
	public float speedMultiplier = 1f;

	public float jumpForce = 600f;

	private bool facingRight = true;
	public bool isGrounded = false;


	//protected Animator animator;


	void Awake() {
		Instance = this;
		groundcheck = transform.Find ("GroundCheck");
	}
	
	
	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundcheck.position , groundradius , GroundLayer);

		float move = Input.GetAxis("Horizontal");

		rigidbody2D.velocity = new Vector2( move * maxSpeed * ((!grounded) ? (0.7f) : (1)) , rigidbody2D.velocity.y );

		if ( (move > 0  && !facingRight) || (move < 0 && facingRight) ) {
			Flip();
		}
	}
	
	void Update() {
		if ( grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) ) {
			grounded = false;
			rigidbody2D.AddForce(new Vector2(0, jumpForce ));
		}
	}
	

	
	private void Flip(){
		facingRight = !facingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}
	
}
