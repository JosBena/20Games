using UnityEngine;

using Statemachine;
using System;
public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb;
	[SerializeField] float jumpStrength = 1f;
	[SerializeField] Animator animator;
	Animator explosion;
	StateMachine stateMachine;
	bool isGrounded;
	bool isDead;
	public bool isFlying { private set; get; }
	private void Awake() {
		rb= GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		//stateMachine
		stateMachine = new StateMachine();
		var runningState = new RunningState(this, animator);
		var flyingState = new FlyingState(this, animator);
		var deadState = new DeadState(this, animator);

		At(runningState, flyingState, new FuncPredicate(() => !isGrounded));
		At(flyingState, runningState, new FuncPredicate(() => isGrounded));

		At(flyingState, deadState, new FuncPredicate(() => isDead));
		At(runningState, deadState, new FuncPredicate(() => isDead));
		At(deadState, flyingState, new FuncPredicate(() => !isDead));


		stateMachine.SetState(runningState);
	}

	void At(IState from, IState to, IPredicate condition) => stateMachine.AddTransition(from, to, condition);
	void AtAny(IState to, IPredicate condition) => stateMachine.AddAnyTransition(to, condition);

	private void Update() {
		stateMachine.Update();
	}

	private void FixedUpdate() {
		stateMachine.FixedUpdate();
	}

	public bool HandleFlying() {
		if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
			rb.AddForce(Vector3.up * jumpStrength, ForceMode2D.Impulse);
			isFlying = true;
		}
		else {
			isFlying = false;
		}
		return isFlying;

	}

	public void Death() {
		
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.CompareTag("Ground")) {
			isGrounded = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag=="Obstacle") isDead = true;
		print("dead");
	}
	private void OnCollisionExit2D(Collision2D collision) {
		if (collision.transform.CompareTag("Ground"))
			isGrounded = false;
	}
}
