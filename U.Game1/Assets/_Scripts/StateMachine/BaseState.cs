using Practice;
using UnityEngine;

namespace StateMachine {

	public abstract class BaseState : IState {
		protected readonly PlayerController player;
		protected readonly Animator animator;

		protected static readonly int flying = Animator.StringToHash("playerFlyingAnim");
		protected static readonly int Dead = Animator.StringToHash("playerDeadAnim");

		protected const float crossFadeDuration = 0.1f;

		protected BaseState(PlayerController player, Animator animator) {
			this.player = player;
			this.animator = animator;
		}

		public virtual void FixedUpdate() {
			// noop
		}

		public virtual void OnEnter() {
			// noop
		}

		public virtual void OnExit() {
			// noop
		}

		public virtual void Update() {
			// noop
		}
	}
}