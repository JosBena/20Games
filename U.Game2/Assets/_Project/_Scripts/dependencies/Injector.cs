using System;
using UnityEngine;

public partial class DependencyInjection {
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
	public  sealed class InjectAttribute : Attribute {
		public InjectAttribute() { }
	}

	[AttributeUsage(AttributeTargets.Method)]
	public sealed class ProvideAttribute : Attribute {
		public ProvideAttribute() { }
	}

	public class ClassA : MonoBehaviour { 
	
	}

	public class ClassB : MonoBehaviour { }

	public interface IDependencyProvider { }


	public class Injector : MonoBehaviour {

	}
}
