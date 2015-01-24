using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public static Movement Instance;

	private Transform groundcheck;
	private float groundradius = 0.1f;
	public bool  grounded = false;
	public bool onChain = false;
	public bool pushing = false;
	public bool hasSister = true;
	private Transform alice;
	private bool canCling = false;

	[SerializeField] private LayerMask GroundLayer;
	public float maxSpeed = 6f;
	public float speedMultiplier = 1f;

	public float jumpForce = 600f;

	public bool facingRight = true;
	public bool isGrounded = false;

	public Vector3 alicePos = new Vector3(0.95f, -0.45f, 0);
	public Animator animator;


	void Awake() {
		Instance = this;
		groundcheck = transform.Find ("GroundCheck");
		animator = GetComponent<Animator>();
		alice = transform.FindChild("Alice");
	}
	
	
	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundcheck.position , groundradius , GroundLayer) || onChain && !hasSister && (!RampScript.Instance.hasRamp);

		float movex = Input.GetAxis("Horizontal");
		float movey = Input.GetAxis("Vertical");

		rigidbody2D.velocity = new Vector2( movex * maxSpeed * ((!grounded) ? (0.7f) : (1)) * ((onChain) ? (0) : (1)) ,  ((onChain) ? (movey * maxSpeed * 0.3f) : (rigidbody2D.velocity.y )) );
		if (Mathf.Abs(movex) > 0 && !hasSister) animator.SetBool("isWalkingAlone", true);
		else if (movex == 0 && !hasSister) animator.SetBool("isWalkingAlone", false);
		else if (Mathf.Abs(movex) > 0 && hasSister)
		{
			animator.SetBool("isWalkingAlone", false);
			animator.SetBool("isWalkingWithSister", true);
			AliceMovement.Instance.aliceAnimator.SetBool("isWalking", true);
		}
		else if (movex == 0 && hasSister)
		{
			animator.SetBool("isWalkingAlone", false);
			animator.SetBool("isWalkingWithSister", false);
			AliceMovement.Instance.aliceAnimator.SetBool("isWalking", false);
		}

		if (!hasSister) animator.SetBool("isWalkingWithSister", false);

		if (!onChain)
		{
			if ((movex > 0 && !facingRight) || (movex < 0 && facingRight))
			{
				Flip();
			}
		}
		else
		{
			if ((movex > 0 && facingRight) || (movex < 0 && !facingRight))
			{
				Flip();
			}
		}

	}
	
	void Update() {
		if (Input.GetKey(KeyCode.LeftShift)) canCling = true;
		if (Input.GetKeyUp(KeyCode.LeftShift)) canCling = false;
		if ( grounded && (Input.GetKeyDown(KeyCode.Space)) && !hasSister && !(RampScript.Instance.hasRamp)) {
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
		

		if (Input.GetKeyDown(KeyCode.F) && hasSister)
		{
			//Afinei thn alice
			StartCoroutine(ReleaseSister());
		}

		animator.SetBool("hasSister", hasSister);

	}


	IEnumerator ReleaseSister()
	{
		while (Input.GetKey(KeyCode.F)) yield return null;
		hasSister = false;
		maxSpeed = 10f;
		transform.DetachChildren();
		AliceMovement.Instance.aliceAnimator.SetBool("isAlone", true);

		groundcheck.SetParent(this.transform);
		yield return null;
 	}

	
	private void Flip(){
		facingRight = !facingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}

	private bool horriblePrograming = true;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Chain" && horriblePrograming == true && !hasSister && canCling)
		{
			onChain = true;
			horriblePrograming = false;
			animator.SetBool("isClimbing", true);
			transform.position = new Vector3(col.transform.position.x, transform.position.y, transform.position.z);
		}

	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Box") animator.SetBool("isPushing", Input.GetAxis("Horizontal") != 0);
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
