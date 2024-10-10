using UnityEngine;

public partial class DependencyInjection {
	public class Provider : MonoBehaviour, IDependencyProvider { }

	public class ServiceA {
		public void Initialize(string message = null) { 
			Debug.Log($"ServiceA.Initialize({message})");
		}
	}
}
