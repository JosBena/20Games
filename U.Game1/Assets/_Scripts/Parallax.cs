using UnityEngine;

namespace Practice {

	public class Parallax : MonoBehaviour {
		private MeshRenderer _meshRenderer;

		[Range(0f, 2f)]
		[SerializeField] private float _animSpeed;

		private void Start() {
			_meshRenderer = GetComponent<MeshRenderer>();
		}

		private void Update() {
			_meshRenderer.material.mainTextureOffset += Vector2.right * _animSpeed * Time.deltaTime;
		}
	}
}