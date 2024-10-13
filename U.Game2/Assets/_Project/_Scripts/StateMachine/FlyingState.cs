using Unity.VisualScripting;
using UnityEngine;

namespace Statemachine {
	public class FlyingState : BaseState {
		bool isDropping;
		public FlyingState(PlayerController player, Animator animator) : base(player, animator) {
			
		}
		
		public override void OnEnter() { 
			
			animator.CrossFade(FlyingHash, crossFadeDuration);
		}



		public override void Update() {
			
			isDropping = !player.HandleFlying();
			if (isDropping) animator.CrossFade(DroppingHash, crossFadeDuration);
			else animator.CrossFade(FlyingHash, crossFadeDuration);
		}
	}


}