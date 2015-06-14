using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax;
}


public class Player : MonoBehaviour {

	public GameObject world;
	//Player
	public GameObject playerGround;
	public Boundary boundary;
	public float speed;
	public float jumpSpeed = 10.0F;
	public float gravity = 20.0F;
	//float forward;
	private Vector3 forwardVector;
	private Rigidbody rigidBody;
	private Animator animator;
	private Vector3 moveDirection = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody> ();
		animator = gameObject.GetComponent <Animator> ();
	}

	void Update() {
		/*
		if (Time.time > 2.5f) {
			if (forward < 1.9f){
				forward += 0.005f;			
			}
		}
		forwardVector = new Vector3(0.0f,0.0f,forward);
		*/

	}
	
	// Update is called once per frame
	void FixedUpdate(){

		//Movement
		/*
		Vector3 movement = new Vector3 ();
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");

		if (anim.GetBool ("IsWalk") == true || anim.GetBool ("IsJog") == true || anim.GetBool ("IsRun") == true) {
			movement.Set (moveHorizontal,0.0f,0.0f);
		}

		rb.velocity = forwardVector * speed;

		if ((rb.position.x >= boundary.xMin && moveHorizontal == -1.0f)
		    || rb.position.x <= boundary.xMax && moveHorizontal == +1.0f) {
			rb.velocity = (movement + forwardVector) * speed;
		}*/

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(0, 0, 0);
			float moveHorizontal = Input.GetAxisRaw ("Horizontal");
			if ((rigidBody.position.x <= boundary.xMin && moveHorizontal == -1.0f)||(rigidBody.position.x + 1 >= boundary.xMax && moveHorizontal == +1.0f) )
				moveDirection.x = Input.GetAxis("Horizontal");
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump") && 
			    ( animator.GetBool ("IsJog") == true || animator.GetBool ("IsRun") == true)){
				moveDirection.y = jumpSpeed;
				moveDirection.x = 0F;
				animator.SetTrigger("Jump");
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		//Animation
		/*
		if (forward > 0.0f && forward <= 1.0f) {
			anim.SetBool ("IsIdle", false);
			anim.SetBool ("IsWalk", true);
			anim.SetBool ("IsJog", false);
			anim.SetBool ("IsRun", false);
			speed = 2;

		} else if (forward > 1.0f && forward <= 2.0f) {
			anim.SetBool ("IsIdle", false);
			anim.SetBool ("IsWalk", false);
			anim.SetBool ("IsJog", true);
			anim.SetBool ("IsRun", false);
			speed = 5;

		} else if (forward > 2.0f) {
			anim.SetBool ("IsIdle", false);
			anim.SetBool ("IsWalk", false);
			anim.SetBool ("IsJog", false);
			anim.SetBool ("IsRun", true);
			speed = 10;

		} else {
			anim.SetBool("IsRun",true);
		}
		*/
	}

	void OnTriggerEnter(Collider collider) 
	{
		//DEATH
		if (collider.gameObject.CompareTag ("Obstacle")) {
			collider.gameObject.SetActive (false);
			//Destroy (collider.gameObject);
			animator.SetBool ("IsJog", false);
			animator.SetTrigger("Die");
			world.GetComponent<WorldRotation>().SetRotationSpeed(0f);

			Vector3 dir = (gameObject.transform.position - world.transform.position).normalized;
			gameObject.transform.position = world.transform.position + 99 * dir;
			gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
			gameObject.transform.Rotate(0,180,0);
			gameObject.transform.SetParent(world.transform);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		}

		/*if (collider.gameObject.CompareTag ("Speed")) {
			collider.gameObject.SetActive (false);
			if (forward < 3.0f) {
				forward = forward + 0.5f;
			}
		} else if (collider.gameObject.CompareTag ("Giant")) {
			collider.gameObject.SetActive (false);
		} else if (collider.gameObject.CompareTag ("Small")) {
			collider.gameObject.SetActive (false);
		}*/
	}
	
}
