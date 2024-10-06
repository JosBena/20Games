using System;
using UnityEngine;

public class Player : MonoBehaviour {
	private Vector3 direction;
	public float gravity = -9.81f;
	private Rigidbody2D _rb;
	[SerializeField] private float strength = 5f;
	[SerializeField] private GameManager gameManager;

	//Sprite
	private SpriteRenderer _spriteRenderer;
	[SerializeField] private Sprite[] _sprites;
	private int _spriteIndex;

	private void Awake() {
		_rb = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnEnable() {
		Vector3 pos = transform.position;
		pos.y = 0;
		transform.position = pos;
		direction = Vector3.zero;
	}

	private void Start() {
		InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {
			direction = Vector3.up * strength;
		}

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began) {
				direction = Vector3.up * strength;
			}
		}

		direction.y += gravity * Time.deltaTime;
		transform.position += direction * Time.deltaTime;
	}

	private void AnimateSprite() {
		_spriteIndex++;

		if (_spriteIndex >= _sprites.Length) {
			_spriteIndex = 0;
		}
		_spriteRenderer.sprite = _sprites[_spriteIndex];
	}

	private void OnTriggerEnter2D(Collider2D collision) => Collisions(collision)?.Invoke();

	private Action Collisions(Collider2D collision) => collision.gameObject.tag switch {
		"Obstacle" => gameManager.GameOver,
		"Scoring" => gameManager.IncreaseScore,
		_ => gameManager.Missing,
	};
}