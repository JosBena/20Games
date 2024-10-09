using Practice;
using UnityEngine;

namespace StateMachine {

	public class DeadState : BaseState {

		public DeadState(PlayerController player, Animator animator) : base(player, animator) {
			animator.CrossFade(Dead, crossFadeDuration);
		}

		public override void FixedUpdate() {
			//call player's move logic
		}
	}
}