using UnityEngine;

namespace Statemachine {
	public interface IState {
		void OnEnter();
		void Update();
		void FixedUpdate();
		void OnExit();
	}

}
