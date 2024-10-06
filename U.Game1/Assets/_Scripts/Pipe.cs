using UnityEngine;

namespace Practice {

	public class Pipe : MonoBehaviour {
		[SerializeField] private float _speed;
		private Vector3 _leftEdge;

		private void OnEnable() {
			_leftEdge.x = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
		}

		private void FixedUpdate() {
			transform.position -= new Vector3(_speed, 0) * Time.deltaTime;
		}

		private void Update() {
			if (transform.position.x < _leftEdge.x) Destroy(gameObject);
		}
	}
}