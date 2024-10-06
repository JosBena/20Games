using UnityEngine;

public class Pipe : MonoBehaviour {
	[SerializeField] private float _speed = 5f;
	private float leftEndge;

	private void Start() {
		leftEndge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
	}

	private void Update() {
		transform.position += Vector3.left * Time.deltaTime * _speed;

		if (transform.position.x < leftEndge) {
			Destroy(gameObject);
		}
	}
}