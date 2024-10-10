using UnityEngine;

public class Parallax : MonoBehaviour
{
	[Range(-1f, 1f), SerializeField] private float scrollSpeed = 0.5f;
	private float offset;
	private MeshRenderer meshRenderer;

	private void Awake() {
		meshRenderer = GetComponent<MeshRenderer>();
	}

	private void Update() {
		meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
	}
}
