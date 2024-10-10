using UnityEngine;

namespace Statemachine {
	public class RunningState : BaseState {
		public RunningState(PlayerController player, Animator animator) : base(player, animator) {
		}

		public override void OnEnter() {
			animator.CrossFade(RunningHash, crossFadeDuration);
		}

		public override void Update() {
			player.HandleFlying();
		}
	}
}