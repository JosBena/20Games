using UnityEngine;

using Statemachine;
public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb;
	[SerializeField] float jumpStrength = 1f;
	[SerializeField] Animator animator;
	StateMachine stateMachine;
	bool isGrounded;
	private void Awake() {
		rb= GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		//stateMachine
		stateMachine = new StateMachine();
		var runningState = new RunningState(this, animator);
		var flyingState = new FlyingState(this, animator);

		At(runningState, flyingState, new FuncPredicate(() => !isGrounded));
		At(flyingState, runningState, new FuncPredicate(() => isGrounded));

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

	public void HandleFlying() {
		if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
			rb.AddForce(Vector3.up * jumpStrength, ForceMode2D.Impulse);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.CompareTag("Ground"))
			isGrounded = true;
	}
	private void OnCollisionExit2D(Collision2D collision) {
		if (collision.transform.CompareTag("Ground"))
			isGrounded = false;
	}
}
