using System;

namespace StateMachine {
	public class FuncPredicate : IPredicate {
		private readonly Func<bool> func;

		public FuncPredicate(Func<bool> func) {
			this.func = func;
		}

		public bool Evaluate() => func.Invoke();
	}
}