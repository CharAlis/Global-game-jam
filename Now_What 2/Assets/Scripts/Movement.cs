using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public static Movement Instance;

	private Transform groundcheck;
	private float groundradius = 0.1f;
	public bool  grounded = false;
	public bool onChain = false;
	public bool pushing = false;
	public bool hasSister = false;

	[SerializeField] private LayerMask GroundLayer;
	private float maxSpeed = 10f;
	public float speedMultiplier = 1f;

	public float jumpForce = 600f;

	private bool facingRight = true;
	public bool isGrounded = false;


	protected Animator animator;


	void Awake() {
		Instance = this;
		groundcheck = transform.Find ("GroundCheck");
		animator = GetComponent<Animator>();
	}
	
	
	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundcheck.position , groundradius , GroundLayer) || onChain && !hasSister;

		float movex = Input.GetAxis("Horizontal");
		float movey = Input.GetAxis("Vertical");

		rigidbody2D.velocity = new Vector2( movex * maxSpeed * ((!grounded) ? (0.7f) : (1)) * ((onChain) ? (0) : (1)) ,  ((onChain) ? (movey * maxSpeed * 0.3f) : (rigidbody2D.velocity.y )) );
		if (Mathf.Abs(movex) > 0 && !hasSister) animator.SetBool("isWalkingAlone", true);
		else if (movex == 0 && !hasSister) animator.SetBool("isWalkingAlone", false);
		else if (Mathf.Abs(movex) > 0 && hasSister) animator.SetBool("isWalkingWithSister", true);
		else if (movex == 0 && hasSister) animator.SetBool("isWalkingWithSister", false);

		if (!onChain)
		{
			if ((movex > 0 && !facingRight) || (movex < 0 && facingRight))
			{
				Flip();
			}
		}
		else
		{
			if ((movex < 0 && !facingRight) || (movex > 0 && facingRight))
			{
				Flip();
			}
		}
	}
	
	void Update() {
		if ( grounded && (Input.GetKeyDown(KeyCode.Space)) && !hasSister) {
			animator.SetBool("isJumping", true);
			if (!onChain)
			{
				rigidbody2D.AddForce(new Vector2(0, jumpForce));
			}
			else
			{
				onChain = false;
				rigidbody2D.AddForce(new Vector2(jumpForce * ((facingRight) ? (1) : (-1)), 0));
			}
			grounded = false;
		}
		animator.SetBool("isOnAir", !grounded);
		if (Input.GetKeyUp(KeyCode.Space))
		{
			animator.SetBool("isJumping", false);
		}
	}


	public float test = 0.5f;
	
	private void Flip(){
		facingRight = !facingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
		if (onChain) transform.Translate(new Vector3(test, 0, 0));
	}

	private bool horriblePrograming = true;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Chain" && horriblePrograming == true && !hasSister )
		{
			onChain = true;
			horriblePrograming = false;
			animator.SetBool("isClimbing", true);
		}

		if (col.tag == "Box")
		{
			animator.SetBool("isPushing", true);
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Chain")
		{
			onChain = false;
			horriblePrograming = true;
			animator.SetBool("isClimbing", false);
		}
		if (col.tag == "Box")
		{
			animator.SetBool("isPushing", false);
		}
	}

}
