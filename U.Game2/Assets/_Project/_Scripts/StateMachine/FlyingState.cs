using UnityEngine;

namespace Statemachine {
	public class FlyingState : BaseState {
		public FlyingState(PlayerController player, Animator animator) : base(player, animator) {
		}

		public override void OnEnter() {
			animator.CrossFade(FlyingHash, crossFadeDuration);
		}

		public override void Update() {
			player.HandleFlying();
		}
	}
}