using UnityEngine;

namespace Statemachine {
	public abstract class BaseState : IState {
		protected readonly PlayerController player;
		protected readonly Animator animator;

		//Animation list here
		protected static readonly int RunningHash = Animator.StringToHash("runningAnim");
		protected static readonly int FlyingHash = Animator.StringToHash("flyingAnim");

		protected const float crossFadeDuration = 0.1f;

		protected BaseState(PlayerController player, Animator animator) {
			this.player = player;
			this.animator = animator;
		}

		public virtual void FixedUpdate() {
			//nope
		}

		public virtual void OnEnter() {
			//nope
		}

		public virtual void OnExit() {
			//nope
		}

		public virtual void Update() {
			//nope
		}
	}
}