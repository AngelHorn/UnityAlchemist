using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{

	public float jumpForce;
	public float speed;
	public AudioClip shot;
	public AudioClip readyToShot;
	public GameObject arrow;

	private bool needShot = false;
	private bool grounded = true;
	private bool isFaceRight = true;
	private bool inputHorizontal = false;
	private bool inputJump = false;
	private bool inputAttack = false;
	Animator animator;
	Rigidbody2D rigidbody2D;
	Transform groundCheck;
	AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		groundCheck = transform.Find ("groundCheck");

		animator = GetComponent<Animator> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void Update ()
	{
		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("Xspeed", Mathf.Abs (rigidbody2D.velocity.x));


		if (Input.GetAxis ("Horizontal") != 0) {
			if (Input.GetAxis ("Horizontal") < 0 && isFaceRight == true) {
				Flip ();
				isFaceRight = false;
			}
			if (Input.GetAxis ("Horizontal") > 0 && isFaceRight != true) {
				Flip ();
				isFaceRight = true;
			}
			inputHorizontal = true;
		}

		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo (0);
		//if shot state is just over
		if (stateInfo.fullPathHash != Animator.StringToHash ("Base Layer.attack") && inputAttack == true) {
			shotArrow ();
			audioSource.clip = shot;
			audioSource.Play ();
			inputAttack = false;
		}

		if (Input.GetButtonDown ("Fire1") && stateInfo.fullPathHash != Animator.StringToHash ("Base Layer.attack") && grounded) {
			animator.SetTrigger ("attack");
			audioSource.clip = readyToShot;
			audioSource.Play ();
			inputAttack = true;
		}

		if (Input.GetButtonDown ("Jump") && grounded && !inputAttack) {
			animator.SetTrigger ("jump");
			inputJump = true;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		if (inputHorizontal) {
			rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, rigidbody2D.velocity.y);
			inputHorizontal = false;
		}

		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		if (inputJump && grounded) {
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
			inputJump = false;
		}
		if (inputAttack) {
			rigidbody2D.velocity = new Vector2 (0, 0);
		}
		//print (grounded);
	}

	void Flip ()
	{
		transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
	}

	void shotArrow ()
	{
		int arrowInstantiateXSpeed = 20;
		Quaternion fuck;
		Vector2 arrowInstantiateVector2;
		if (isFaceRight) {
			fuck = Quaternion.Euler (new Vector2 (0, 0));
			arrowInstantiateVector2 = new Vector2 (arrowInstantiateXSpeed, 0);
		} else {
			fuck = Quaternion.Euler (new Vector2 (0, 180f));
			arrowInstantiateVector2 = new Vector2 (-arrowInstantiateXSpeed, 0);
		}
		Rigidbody2D arrowInstantiate = (Instantiate (arrow, transform.position, fuck) as GameObject).GetComponent<Rigidbody2D> ();
		arrowInstantiate.velocity = arrowInstantiateVector2;
	}
}
