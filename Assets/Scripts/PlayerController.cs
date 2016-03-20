using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	public bool moveRight;

	public Transform groundCheck;
	public Transform groundCheck2;
	public Transform wallCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool grounded2;
	private bool walled;
	public Sprite left;
	public Sprite right;

	public Transform firePoint;
	public Transform firePoint2;
	public GameObject ninjaStar;
	public GameObject ninjaStar2;

	// Use this for initialization
	void Start () {
		     
	}

	void FixedUpdate () {
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		grounded2 = Physics2D.OverlapCircle (groundCheck2.position, groundCheckRadius, whatIsGround);
		walled = Physics2D.OverlapCircle (wallCheck.position, groundCheckRadius, whatIsGround);

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Comma) && (grounded || grounded2)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
		}

		if (moveRight) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}

		if (Input.GetKeyDown (KeyCode.Slash)) {
			moveRight = !moveRight;
			wallCheck.localPosition = -wallCheck.localPosition;
			SetSprite ();
		}

		if (walled) {
			moveRight = !moveRight;
			wallCheck.localPosition = -wallCheck.localPosition;
			SetSprite ();
		}

		if (Input.GetKeyDown (KeyCode.Period)) {
			if (moveRight) {
				Instantiate (ninjaStar2, firePoint2.position, firePoint2.rotation);
			} else {
				Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			}
		}
			
	}

	void SetSprite() {
		
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();

		renderer.sprite = moveRight ? right : left;

	}
}