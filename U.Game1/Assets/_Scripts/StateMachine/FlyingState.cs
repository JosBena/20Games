using Practice;
using UnityEngine;

namespace StateMachine {

	public class FlyingState : BaseState {

		public FlyingState(PlayerController player, Animator animator) : base(player, animator) {
		}

		public override void OnEnter() {
			animator.CrossFade(flying, crossFadeDuration);
		}

		public override void FixedUpdate() {
			//call player to start jumping
		}

		public override void Update() {
			player.HandleJump();
		}
	}

	public class JumpState : BaseState {

		public JumpState(PlayerController player, Animator animator) : base(player, animator) {
		}

		public override void OnEnter() {
		}

		public override void FixedUpdate() {
			player.HandleJump();
		}
	}
}