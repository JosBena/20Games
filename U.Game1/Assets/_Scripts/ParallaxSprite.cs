using UnityEngine;

public class ParallaxSprite : MonoBehaviour {
	private SpriteRenderer _spriteRenderer;
	private Material material;

	[Range(0f, 2f)]
	[SerializeField] private float _animSpeed;

	private void Awake() {
		material = new Material(GetComponent<SpriteRenderer>().material);
		GetComponent<SpriteRenderer>().material = material;
	}

	private void Update() {
		material.mainTextureOffset += Vector2.right * _animSpeed * Time.deltaTime;
	}
}